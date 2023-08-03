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
   public class loadauditproduto : GXProcedure
   {
      public loadauditproduto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditproduto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_PrdID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17PrdID = aP2_PrdID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_PrdID ,
                                 string aP3_ActualMode )
      {
         loadauditproduto objloadauditproduto;
         objloadauditproduto = new loadauditproduto();
         objloadauditproduto.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditproduto.AV11AuditingObject = aP1_AuditingObject;
         objloadauditproduto.AV17PrdID = aP2_PrdID;
         objloadauditproduto.AV15ActualMode = aP3_ActualMode;
         objloadauditproduto.context.SetSubmitInitialConfig(context);
         objloadauditproduto.initialize();
         Submit( executePrivateCatch,objloadauditproduto);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditproduto)stateInfo).executePrivate();
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
         /* Using cursor P00732 */
         pr_default.execute(0, new Object[] {AV17PrdID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A220PrdID = P00732_A220PrdID[0];
            A221PrdCodigo = P00732_A221PrdCodigo[0];
            A222PrdNome = P00732_A222PrdNome[0];
            A223PrdInsData = P00732_A223PrdInsData[0];
            A224PrdInsHora = P00732_A224PrdInsHora[0];
            A225PrdInsDataHora = P00732_A225PrdInsDataHora[0];
            A226PrdInsUsuID = P00732_A226PrdInsUsuID[0];
            n226PrdInsUsuID = P00732_n226PrdInsUsuID[0];
            A227PrdUpdData = P00732_A227PrdUpdData[0];
            n227PrdUpdData = P00732_n227PrdUpdData[0];
            A228PrdUpdHora = P00732_A228PrdUpdHora[0];
            n228PrdUpdHora = P00732_n228PrdUpdHora[0];
            A229PrdUpdDataHora = P00732_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = P00732_n229PrdUpdDataHora[0];
            A230PrdUpdUsuID = P00732_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = P00732_n230PrdUpdUsuID[0];
            A231PrdAtivo = P00732_A231PrdAtivo[0];
            A232PrdTipoID = P00732_A232PrdTipoID[0];
            A233PrdTipoSigla = P00732_A233PrdTipoSigla[0];
            A234PrdTipoNome = P00732_A234PrdTipoNome[0];
            A620PrdDel = P00732_A620PrdDel[0];
            A621PrdDelDataHora = P00732_A621PrdDelDataHora[0];
            n621PrdDelDataHora = P00732_n621PrdDelDataHora[0];
            A622PrdDelData = P00732_A622PrdDelData[0];
            n622PrdDelData = P00732_n622PrdDelData[0];
            A623PrdDelHora = P00732_A623PrdDelHora[0];
            n623PrdDelHora = P00732_n623PrdDelHora[0];
            A624PrdDelUsuId = P00732_A624PrdDelUsuId[0];
            n624PrdDelUsuId = P00732_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = P00732_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = P00732_n625PrdDelUsuNome[0];
            A233PrdTipoSigla = P00732_A233PrdTipoSigla[0];
            A234PrdTipoNome = P00732_A234PrdTipoNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_produto";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A220PrdID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdCodigo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A221PrdCodigo;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A222PrdNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A223PrdInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A226PrdInsUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A227PrdUpdData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Útlima Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A230PrdUpdUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A231PrdAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto ou Serviço";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A233PrdTipoSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Tipo do Produto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A234PrdTipoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A620PrdDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A621PrdDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A622PrdDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A623PrdDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A624PrdDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A625PrdDelUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P00733 */
         pr_default.execute(1, new Object[] {AV17PrdID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A220PrdID = P00733_A220PrdID[0];
            A221PrdCodigo = P00733_A221PrdCodigo[0];
            A222PrdNome = P00733_A222PrdNome[0];
            A223PrdInsData = P00733_A223PrdInsData[0];
            A224PrdInsHora = P00733_A224PrdInsHora[0];
            A225PrdInsDataHora = P00733_A225PrdInsDataHora[0];
            A226PrdInsUsuID = P00733_A226PrdInsUsuID[0];
            n226PrdInsUsuID = P00733_n226PrdInsUsuID[0];
            A227PrdUpdData = P00733_A227PrdUpdData[0];
            n227PrdUpdData = P00733_n227PrdUpdData[0];
            A228PrdUpdHora = P00733_A228PrdUpdHora[0];
            n228PrdUpdHora = P00733_n228PrdUpdHora[0];
            A229PrdUpdDataHora = P00733_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = P00733_n229PrdUpdDataHora[0];
            A230PrdUpdUsuID = P00733_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = P00733_n230PrdUpdUsuID[0];
            A231PrdAtivo = P00733_A231PrdAtivo[0];
            A232PrdTipoID = P00733_A232PrdTipoID[0];
            A233PrdTipoSigla = P00733_A233PrdTipoSigla[0];
            A234PrdTipoNome = P00733_A234PrdTipoNome[0];
            A620PrdDel = P00733_A620PrdDel[0];
            A621PrdDelDataHora = P00733_A621PrdDelDataHora[0];
            n621PrdDelDataHora = P00733_n621PrdDelDataHora[0];
            A622PrdDelData = P00733_A622PrdDelData[0];
            n622PrdDelData = P00733_n622PrdDelData[0];
            A623PrdDelHora = P00733_A623PrdDelHora[0];
            n623PrdDelHora = P00733_n623PrdDelHora[0];
            A624PrdDelUsuId = P00733_A624PrdDelUsuId[0];
            n624PrdDelUsuId = P00733_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = P00733_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = P00733_n625PrdDelUsuNome[0];
            A233PrdTipoSigla = P00733_A233PrdTipoSigla[0];
            A234PrdTipoNome = P00733_A234PrdTipoNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_produto";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A220PrdID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdCodigo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Código";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A221PrdCodigo;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A222PrdNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A223PrdInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A226PrdInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A227PrdUpdData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Útlima Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdUpdUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A230PrdUpdUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A231PrdAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto ou Serviço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Produto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A233PrdTipoSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdTipoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Tipo do Produto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A234PrdTipoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A620PrdDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A621PrdDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A622PrdDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A623PrdDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A624PrdDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PrdDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A625PrdDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV20GXV1 = 1;
               while ( AV20GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV20GXV1));
                  AV21GXV2 = 1;
                  while ( AV21GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV21GXV2));
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
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdInsData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A223PrdInsData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdInsHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdInsDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdInsUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A226PrdInsUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdUpdData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A227PrdUpdData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdUpdHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdUpdDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdUpdUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A230PrdUpdUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdAtivo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A231PrdAtivo);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdTipoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A232PrdTipoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdTipoSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A233PrdTipoSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdTipoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A234PrdTipoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A620PrdDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A621PrdDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A622PrdDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A623PrdDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A624PrdDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PrdDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A625PrdDelUsuNome;
                     }
                     AV21GXV2 = (int)(AV21GXV2+1);
                  }
                  AV20GXV1 = (int)(AV20GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         P00732_A220PrdID = new Guid[] {Guid.Empty} ;
         P00732_A221PrdCodigo = new string[] {""} ;
         P00732_A222PrdNome = new string[] {""} ;
         P00732_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         P00732_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         P00732_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00732_A226PrdInsUsuID = new string[] {""} ;
         P00732_n226PrdInsUsuID = new bool[] {false} ;
         P00732_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         P00732_n227PrdUpdData = new bool[] {false} ;
         P00732_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00732_n228PrdUpdHora = new bool[] {false} ;
         P00732_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00732_n229PrdUpdDataHora = new bool[] {false} ;
         P00732_A230PrdUpdUsuID = new string[] {""} ;
         P00732_n230PrdUpdUsuID = new bool[] {false} ;
         P00732_A231PrdAtivo = new bool[] {false} ;
         P00732_A232PrdTipoID = new int[1] ;
         P00732_A233PrdTipoSigla = new string[] {""} ;
         P00732_A234PrdTipoNome = new string[] {""} ;
         P00732_A620PrdDel = new bool[] {false} ;
         P00732_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00732_n621PrdDelDataHora = new bool[] {false} ;
         P00732_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         P00732_n622PrdDelData = new bool[] {false} ;
         P00732_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         P00732_n623PrdDelHora = new bool[] {false} ;
         P00732_A624PrdDelUsuId = new string[] {""} ;
         P00732_n624PrdDelUsuId = new bool[] {false} ;
         P00732_A625PrdDelUsuNome = new string[] {""} ;
         P00732_n625PrdDelUsuNome = new bool[] {false} ;
         A220PrdID = Guid.Empty;
         A221PrdCodigo = "";
         A222PrdNome = "";
         A223PrdInsData = DateTime.MinValue;
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         A226PrdInsUsuID = "";
         A227PrdUpdData = DateTime.MinValue;
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         A230PrdUpdUsuID = "";
         A233PrdTipoSigla = "";
         A234PrdTipoNome = "";
         A621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         A622PrdDelData = (DateTime)(DateTime.MinValue);
         A623PrdDelHora = (DateTime)(DateTime.MinValue);
         A624PrdDelUsuId = "";
         A625PrdDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00733_A220PrdID = new Guid[] {Guid.Empty} ;
         P00733_A221PrdCodigo = new string[] {""} ;
         P00733_A222PrdNome = new string[] {""} ;
         P00733_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         P00733_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         P00733_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00733_A226PrdInsUsuID = new string[] {""} ;
         P00733_n226PrdInsUsuID = new bool[] {false} ;
         P00733_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         P00733_n227PrdUpdData = new bool[] {false} ;
         P00733_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00733_n228PrdUpdHora = new bool[] {false} ;
         P00733_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00733_n229PrdUpdDataHora = new bool[] {false} ;
         P00733_A230PrdUpdUsuID = new string[] {""} ;
         P00733_n230PrdUpdUsuID = new bool[] {false} ;
         P00733_A231PrdAtivo = new bool[] {false} ;
         P00733_A232PrdTipoID = new int[1] ;
         P00733_A233PrdTipoSigla = new string[] {""} ;
         P00733_A234PrdTipoNome = new string[] {""} ;
         P00733_A620PrdDel = new bool[] {false} ;
         P00733_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00733_n621PrdDelDataHora = new bool[] {false} ;
         P00733_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         P00733_n622PrdDelData = new bool[] {false} ;
         P00733_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         P00733_n623PrdDelHora = new bool[] {false} ;
         P00733_A624PrdDelUsuId = new string[] {""} ;
         P00733_n624PrdDelUsuId = new bool[] {false} ;
         P00733_A625PrdDelUsuNome = new string[] {""} ;
         P00733_n625PrdDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditproduto__default(),
            new Object[][] {
                new Object[] {
               P00732_A220PrdID, P00732_A221PrdCodigo, P00732_A222PrdNome, P00732_A223PrdInsData, P00732_A224PrdInsHora, P00732_A225PrdInsDataHora, P00732_A226PrdInsUsuID, P00732_n226PrdInsUsuID, P00732_A227PrdUpdData, P00732_n227PrdUpdData,
               P00732_A228PrdUpdHora, P00732_n228PrdUpdHora, P00732_A229PrdUpdDataHora, P00732_n229PrdUpdDataHora, P00732_A230PrdUpdUsuID, P00732_n230PrdUpdUsuID, P00732_A231PrdAtivo, P00732_A232PrdTipoID, P00732_A233PrdTipoSigla, P00732_A234PrdTipoNome,
               P00732_A620PrdDel, P00732_A621PrdDelDataHora, P00732_n621PrdDelDataHora, P00732_A622PrdDelData, P00732_n622PrdDelData, P00732_A623PrdDelHora, P00732_n623PrdDelHora, P00732_A624PrdDelUsuId, P00732_n624PrdDelUsuId, P00732_A625PrdDelUsuNome,
               P00732_n625PrdDelUsuNome
               }
               , new Object[] {
               P00733_A220PrdID, P00733_A221PrdCodigo, P00733_A222PrdNome, P00733_A223PrdInsData, P00733_A224PrdInsHora, P00733_A225PrdInsDataHora, P00733_A226PrdInsUsuID, P00733_n226PrdInsUsuID, P00733_A227PrdUpdData, P00733_n227PrdUpdData,
               P00733_A228PrdUpdHora, P00733_n228PrdUpdHora, P00733_A229PrdUpdDataHora, P00733_n229PrdUpdDataHora, P00733_A230PrdUpdUsuID, P00733_n230PrdUpdUsuID, P00733_A231PrdAtivo, P00733_A232PrdTipoID, P00733_A233PrdTipoSigla, P00733_A234PrdTipoNome,
               P00733_A620PrdDel, P00733_A621PrdDelDataHora, P00733_n621PrdDelDataHora, P00733_A622PrdDelData, P00733_n622PrdDelData, P00733_A623PrdDelHora, P00733_n623PrdDelHora, P00733_A624PrdDelUsuId, P00733_n624PrdDelUsuId, P00733_A625PrdDelUsuNome,
               P00733_n625PrdDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A226PrdInsUsuID ;
      private string A230PrdUpdUsuID ;
      private string A624PrdDelUsuId ;
      private DateTime A224PrdInsHora ;
      private DateTime A225PrdInsDataHora ;
      private DateTime A228PrdUpdHora ;
      private DateTime A229PrdUpdDataHora ;
      private DateTime A621PrdDelDataHora ;
      private DateTime A622PrdDelData ;
      private DateTime A623PrdDelHora ;
      private DateTime A223PrdInsData ;
      private DateTime A227PrdUpdData ;
      private bool returnInSub ;
      private bool n226PrdInsUsuID ;
      private bool n227PrdUpdData ;
      private bool n228PrdUpdHora ;
      private bool n229PrdUpdDataHora ;
      private bool n230PrdUpdUsuID ;
      private bool A231PrdAtivo ;
      private bool A620PrdDel ;
      private bool n621PrdDelDataHora ;
      private bool n622PrdDelData ;
      private bool n623PrdDelHora ;
      private bool n624PrdDelUsuId ;
      private bool n625PrdDelUsuNome ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A233PrdTipoSigla ;
      private string A234PrdTipoNome ;
      private string A625PrdDelUsuNome ;
      private Guid AV17PrdID ;
      private Guid A220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00732_A220PrdID ;
      private string[] P00732_A221PrdCodigo ;
      private string[] P00732_A222PrdNome ;
      private DateTime[] P00732_A223PrdInsData ;
      private DateTime[] P00732_A224PrdInsHora ;
      private DateTime[] P00732_A225PrdInsDataHora ;
      private string[] P00732_A226PrdInsUsuID ;
      private bool[] P00732_n226PrdInsUsuID ;
      private DateTime[] P00732_A227PrdUpdData ;
      private bool[] P00732_n227PrdUpdData ;
      private DateTime[] P00732_A228PrdUpdHora ;
      private bool[] P00732_n228PrdUpdHora ;
      private DateTime[] P00732_A229PrdUpdDataHora ;
      private bool[] P00732_n229PrdUpdDataHora ;
      private string[] P00732_A230PrdUpdUsuID ;
      private bool[] P00732_n230PrdUpdUsuID ;
      private bool[] P00732_A231PrdAtivo ;
      private int[] P00732_A232PrdTipoID ;
      private string[] P00732_A233PrdTipoSigla ;
      private string[] P00732_A234PrdTipoNome ;
      private bool[] P00732_A620PrdDel ;
      private DateTime[] P00732_A621PrdDelDataHora ;
      private bool[] P00732_n621PrdDelDataHora ;
      private DateTime[] P00732_A622PrdDelData ;
      private bool[] P00732_n622PrdDelData ;
      private DateTime[] P00732_A623PrdDelHora ;
      private bool[] P00732_n623PrdDelHora ;
      private string[] P00732_A624PrdDelUsuId ;
      private bool[] P00732_n624PrdDelUsuId ;
      private string[] P00732_A625PrdDelUsuNome ;
      private bool[] P00732_n625PrdDelUsuNome ;
      private Guid[] P00733_A220PrdID ;
      private string[] P00733_A221PrdCodigo ;
      private string[] P00733_A222PrdNome ;
      private DateTime[] P00733_A223PrdInsData ;
      private DateTime[] P00733_A224PrdInsHora ;
      private DateTime[] P00733_A225PrdInsDataHora ;
      private string[] P00733_A226PrdInsUsuID ;
      private bool[] P00733_n226PrdInsUsuID ;
      private DateTime[] P00733_A227PrdUpdData ;
      private bool[] P00733_n227PrdUpdData ;
      private DateTime[] P00733_A228PrdUpdHora ;
      private bool[] P00733_n228PrdUpdHora ;
      private DateTime[] P00733_A229PrdUpdDataHora ;
      private bool[] P00733_n229PrdUpdDataHora ;
      private string[] P00733_A230PrdUpdUsuID ;
      private bool[] P00733_n230PrdUpdUsuID ;
      private bool[] P00733_A231PrdAtivo ;
      private int[] P00733_A232PrdTipoID ;
      private string[] P00733_A233PrdTipoSigla ;
      private string[] P00733_A234PrdTipoNome ;
      private bool[] P00733_A620PrdDel ;
      private DateTime[] P00733_A621PrdDelDataHora ;
      private bool[] P00733_n621PrdDelDataHora ;
      private DateTime[] P00733_A622PrdDelData ;
      private bool[] P00733_n622PrdDelData ;
      private DateTime[] P00733_A623PrdDelHora ;
      private bool[] P00733_n623PrdDelHora ;
      private string[] P00733_A624PrdDelUsuId ;
      private bool[] P00733_n624PrdDelUsuId ;
      private string[] P00733_A625PrdDelUsuNome ;
      private bool[] P00733_n625PrdDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditproduto__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00732;
          prmP00732 = new Object[] {
          new ParDef("AV17PrdID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00733;
          prmP00733 = new Object[] {
          new ParDef("AV17PrdID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00732", "SELECT T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdInsData, T1.PrdInsHora, T1.PrdInsDataHora, T1.PrdInsUsuID, T1.PrdUpdData, T1.PrdUpdHora, T1.PrdUpdDataHora, T1.PrdUpdUsuID, T1.PrdAtivo, T1.PrdTipoID AS PrdTipoID, T2.PrtSigla AS PrdTipoSigla, T2.PrtNome AS PrdTipoNome, T1.PrdDel, T1.PrdDelDataHora, T1.PrdDelData, T1.PrdDelHora, T1.PrdDelUsuId, T1.PrdDelUsuNome FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID) WHERE T1.PrdID = :AV17PrdID ORDER BY T1.PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00732,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00733", "SELECT T1.PrdID, T1.PrdCodigo, T1.PrdNome, T1.PrdInsData, T1.PrdInsHora, T1.PrdInsDataHora, T1.PrdInsUsuID, T1.PrdUpdData, T1.PrdUpdHora, T1.PrdUpdDataHora, T1.PrdUpdUsuID, T1.PrdAtivo, T1.PrdTipoID AS PrdTipoID, T2.PrtSigla AS PrdTipoSigla, T2.PrtNome AS PrdTipoNome, T1.PrdDel, T1.PrdDelDataHora, T1.PrdDelData, T1.PrdDelHora, T1.PrdDelUsuId, T1.PrdDelUsuNome FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID) WHERE T1.PrdID = :AV17PrdID ORDER BY T1.PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00733,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((string[]) buf[6])[0] = rslt.getString(7, 40);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((bool[]) buf[16])[0] = rslt.getBool(12);
                ((int[]) buf[17])[0] = rslt.getInt(13);
                ((string[]) buf[18])[0] = rslt.getVarchar(14);
                ((string[]) buf[19])[0] = rslt.getVarchar(15);
                ((bool[]) buf[20])[0] = rslt.getBool(16);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(17, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getString(20, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((string[]) buf[29])[0] = rslt.getVarchar(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((string[]) buf[6])[0] = rslt.getString(7, 40);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((bool[]) buf[16])[0] = rslt.getBool(12);
                ((int[]) buf[17])[0] = rslt.getInt(13);
                ((string[]) buf[18])[0] = rslt.getVarchar(14);
                ((string[]) buf[19])[0] = rslt.getVarchar(15);
                ((bool[]) buf[20])[0] = rslt.getBool(16);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(17, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getString(20, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((string[]) buf[29])[0] = rslt.getVarchar(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                return;
       }
    }

 }

}
