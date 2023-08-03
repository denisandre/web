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
   public class loadauditcliente : GXProcedure
   {
      public loadauditcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditcliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_CliID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17CliID = aP2_CliID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_CliID ,
                                 string aP3_ActualMode )
      {
         loadauditcliente objloadauditcliente;
         objloadauditcliente = new loadauditcliente();
         objloadauditcliente.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditcliente.AV11AuditingObject = aP1_AuditingObject;
         objloadauditcliente.AV17CliID = aP2_CliID;
         objloadauditcliente.AV15ActualMode = aP3_ActualMode;
         objloadauditcliente.context.SetSubmitInitialConfig(context);
         objloadauditcliente.initialize();
         Submit( executePrivateCatch,objloadauditcliente);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditcliente)stateInfo).executePrivate();
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
         /* Using cursor P00702 */
         pr_default.execute(0, new Object[] {AV17CliID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A158CliID = P00702_A158CliID[0];
            A159CliMatricula = P00702_A159CliMatricula[0];
            A160CliNomeFamiliar = P00702_A160CliNomeFamiliar[0];
            A165CliTipo = P00702_A165CliTipo[0];
            A161CliInsData = P00702_A161CliInsData[0];
            A162CliInsHora = P00702_A162CliInsHora[0];
            A163CliInsDataHora = P00702_A163CliInsDataHora[0];
            A164CliInsUserID = P00702_A164CliInsUserID[0];
            n164CliInsUserID = P00702_n164CliInsUserID[0];
            A393CliInsUserNome = P00702_A393CliInsUserNome[0];
            n393CliInsUserNome = P00702_n393CliInsUserNome[0];
            A177CliiUpdData = P00702_A177CliiUpdData[0];
            n177CliiUpdData = P00702_n177CliiUpdData[0];
            A178CliUpdHora = P00702_A178CliUpdHora[0];
            n178CliUpdHora = P00702_n178CliUpdHora[0];
            A179CliUpdDataHora = P00702_A179CliUpdDataHora[0];
            n179CliUpdDataHora = P00702_n179CliUpdDataHora[0];
            A180CliUpdUserID = P00702_A180CliUpdUserID[0];
            n180CliUpdUserID = P00702_n180CliUpdUserID[0];
            A394CliUpdUserNome = P00702_A394CliUpdUserNome[0];
            n394CliUpdUserNome = P00702_n394CliUpdUserNome[0];
            A196CliVersao = P00702_A196CliVersao[0];
            A197CliAtivo = P00702_A197CliAtivo[0];
            A524CliDel = P00702_A524CliDel[0];
            A525CliDelDataHora = P00702_A525CliDelDataHora[0];
            n525CliDelDataHora = P00702_n525CliDelDataHora[0];
            A526CliDelData = P00702_A526CliDelData[0];
            n526CliDelData = P00702_n526CliDelData[0];
            A527CliDelHora = P00702_A527CliDelHora[0];
            n527CliDelHora = P00702_n527CliDelHora[0];
            A528CliDelUsuId = P00702_A528CliDelUsuId[0];
            n528CliDelUsuId = P00702_n528CliDelUsuId[0];
            A529CliDelUsuNome = P00702_A529CliDelUsuNome[0];
            n529CliDelUsuNome = P00702_n529CliDelUsuNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_cliente";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A158CliID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliMatricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A159CliMatricula), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliNomeFamiliar";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A160CliNomeFamiliar;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliTipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A165CliTipo), 1, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A161CliInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsUserID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A164CliInsUserID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsUserNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A393CliInsUserNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliiUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A177CliiUpdData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Altera;cão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A178CliUpdHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A179CliUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdUserID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A180CliUpdUserID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdUserNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A394CliUpdUserNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliVersao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Cadastro";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A196CliVersao), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A197CliAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A524CliDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A525CliDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A526CliDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A527CliDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A528CliDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A529CliDelUsuNome;
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
         /* Using cursor P00703 */
         pr_default.execute(1, new Object[] {AV17CliID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A158CliID = P00703_A158CliID[0];
            A159CliMatricula = P00703_A159CliMatricula[0];
            A160CliNomeFamiliar = P00703_A160CliNomeFamiliar[0];
            A165CliTipo = P00703_A165CliTipo[0];
            A161CliInsData = P00703_A161CliInsData[0];
            A162CliInsHora = P00703_A162CliInsHora[0];
            A163CliInsDataHora = P00703_A163CliInsDataHora[0];
            A164CliInsUserID = P00703_A164CliInsUserID[0];
            n164CliInsUserID = P00703_n164CliInsUserID[0];
            A393CliInsUserNome = P00703_A393CliInsUserNome[0];
            n393CliInsUserNome = P00703_n393CliInsUserNome[0];
            A177CliiUpdData = P00703_A177CliiUpdData[0];
            n177CliiUpdData = P00703_n177CliiUpdData[0];
            A178CliUpdHora = P00703_A178CliUpdHora[0];
            n178CliUpdHora = P00703_n178CliUpdHora[0];
            A179CliUpdDataHora = P00703_A179CliUpdDataHora[0];
            n179CliUpdDataHora = P00703_n179CliUpdDataHora[0];
            A180CliUpdUserID = P00703_A180CliUpdUserID[0];
            n180CliUpdUserID = P00703_n180CliUpdUserID[0];
            A394CliUpdUserNome = P00703_A394CliUpdUserNome[0];
            n394CliUpdUserNome = P00703_n394CliUpdUserNome[0];
            A196CliVersao = P00703_A196CliVersao[0];
            A197CliAtivo = P00703_A197CliAtivo[0];
            A524CliDel = P00703_A524CliDel[0];
            A525CliDelDataHora = P00703_A525CliDelDataHora[0];
            n525CliDelDataHora = P00703_n525CliDelDataHora[0];
            A526CliDelData = P00703_A526CliDelData[0];
            n526CliDelData = P00703_n526CliDelData[0];
            A527CliDelHora = P00703_A527CliDelHora[0];
            n527CliDelHora = P00703_n527CliDelHora[0];
            A528CliDelUsuId = P00703_A528CliDelUsuId[0];
            n528CliDelUsuId = P00703_n528CliDelUsuId[0];
            A529CliDelUsuNome = P00703_A529CliDelUsuNome[0];
            n529CliDelUsuNome = P00703_n529CliDelUsuNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_cliente";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A158CliID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliMatricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A159CliMatricula), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliNomeFamiliar";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A160CliNomeFamiliar;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliTipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A165CliTipo), 1, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A161CliInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Incluído em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsUserID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A164CliInsUserID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliInsUserNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A393CliInsUserNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliiUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A177CliiUpdData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Altera;cão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A178CliUpdHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A179CliUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdUserID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A180CliUpdUserID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliUpdUserNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A394CliUpdUserNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliVersao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Cadastro";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A196CliVersao), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A197CliAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A524CliDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A525CliDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A526CliDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A527CliDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A528CliDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A529CliDelUsuNome;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A158CliID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliMatricula") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A159CliMatricula), 12, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliNomeFamiliar") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A160CliNomeFamiliar;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliTipo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A165CliTipo), 1, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliInsData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A161CliInsData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliInsHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliInsDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliInsUserID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A164CliInsUserID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliInsUserNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A393CliInsUserNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliiUpdData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A177CliiUpdData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliUpdHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A178CliUpdHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliUpdDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A179CliUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliUpdUserID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A180CliUpdUserID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliUpdUserNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A394CliUpdUserNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliVersao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A196CliVersao), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliAtivo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A197CliAtivo);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A524CliDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A525CliDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A526CliDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A527CliDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A528CliDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A529CliDelUsuNome;
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
         P00702_A158CliID = new Guid[] {Guid.Empty} ;
         P00702_A159CliMatricula = new long[1] ;
         P00702_A160CliNomeFamiliar = new string[] {""} ;
         P00702_A165CliTipo = new short[1] ;
         P00702_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         P00702_A162CliInsHora = new DateTime[] {DateTime.MinValue} ;
         P00702_A163CliInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00702_A164CliInsUserID = new string[] {""} ;
         P00702_n164CliInsUserID = new bool[] {false} ;
         P00702_A393CliInsUserNome = new string[] {""} ;
         P00702_n393CliInsUserNome = new bool[] {false} ;
         P00702_A177CliiUpdData = new DateTime[] {DateTime.MinValue} ;
         P00702_n177CliiUpdData = new bool[] {false} ;
         P00702_A178CliUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00702_n178CliUpdHora = new bool[] {false} ;
         P00702_A179CliUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00702_n179CliUpdDataHora = new bool[] {false} ;
         P00702_A180CliUpdUserID = new string[] {""} ;
         P00702_n180CliUpdUserID = new bool[] {false} ;
         P00702_A394CliUpdUserNome = new string[] {""} ;
         P00702_n394CliUpdUserNome = new bool[] {false} ;
         P00702_A196CliVersao = new short[1] ;
         P00702_A197CliAtivo = new bool[] {false} ;
         P00702_A524CliDel = new bool[] {false} ;
         P00702_A525CliDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00702_n525CliDelDataHora = new bool[] {false} ;
         P00702_A526CliDelData = new DateTime[] {DateTime.MinValue} ;
         P00702_n526CliDelData = new bool[] {false} ;
         P00702_A527CliDelHora = new DateTime[] {DateTime.MinValue} ;
         P00702_n527CliDelHora = new bool[] {false} ;
         P00702_A528CliDelUsuId = new string[] {""} ;
         P00702_n528CliDelUsuId = new bool[] {false} ;
         P00702_A529CliDelUsuNome = new string[] {""} ;
         P00702_n529CliDelUsuNome = new bool[] {false} ;
         A158CliID = Guid.Empty;
         A160CliNomeFamiliar = "";
         A161CliInsData = DateTime.MinValue;
         A162CliInsHora = (DateTime)(DateTime.MinValue);
         A163CliInsDataHora = (DateTime)(DateTime.MinValue);
         A164CliInsUserID = "";
         A393CliInsUserNome = "";
         A177CliiUpdData = DateTime.MinValue;
         A178CliUpdHora = (DateTime)(DateTime.MinValue);
         A179CliUpdDataHora = (DateTime)(DateTime.MinValue);
         A180CliUpdUserID = "";
         A394CliUpdUserNome = "";
         A525CliDelDataHora = (DateTime)(DateTime.MinValue);
         A526CliDelData = (DateTime)(DateTime.MinValue);
         A527CliDelHora = (DateTime)(DateTime.MinValue);
         A528CliDelUsuId = "";
         A529CliDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00703_A158CliID = new Guid[] {Guid.Empty} ;
         P00703_A159CliMatricula = new long[1] ;
         P00703_A160CliNomeFamiliar = new string[] {""} ;
         P00703_A165CliTipo = new short[1] ;
         P00703_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         P00703_A162CliInsHora = new DateTime[] {DateTime.MinValue} ;
         P00703_A163CliInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00703_A164CliInsUserID = new string[] {""} ;
         P00703_n164CliInsUserID = new bool[] {false} ;
         P00703_A393CliInsUserNome = new string[] {""} ;
         P00703_n393CliInsUserNome = new bool[] {false} ;
         P00703_A177CliiUpdData = new DateTime[] {DateTime.MinValue} ;
         P00703_n177CliiUpdData = new bool[] {false} ;
         P00703_A178CliUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00703_n178CliUpdHora = new bool[] {false} ;
         P00703_A179CliUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00703_n179CliUpdDataHora = new bool[] {false} ;
         P00703_A180CliUpdUserID = new string[] {""} ;
         P00703_n180CliUpdUserID = new bool[] {false} ;
         P00703_A394CliUpdUserNome = new string[] {""} ;
         P00703_n394CliUpdUserNome = new bool[] {false} ;
         P00703_A196CliVersao = new short[1] ;
         P00703_A197CliAtivo = new bool[] {false} ;
         P00703_A524CliDel = new bool[] {false} ;
         P00703_A525CliDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00703_n525CliDelDataHora = new bool[] {false} ;
         P00703_A526CliDelData = new DateTime[] {DateTime.MinValue} ;
         P00703_n526CliDelData = new bool[] {false} ;
         P00703_A527CliDelHora = new DateTime[] {DateTime.MinValue} ;
         P00703_n527CliDelHora = new bool[] {false} ;
         P00703_A528CliDelUsuId = new string[] {""} ;
         P00703_n528CliDelUsuId = new bool[] {false} ;
         P00703_A529CliDelUsuNome = new string[] {""} ;
         P00703_n529CliDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditcliente__default(),
            new Object[][] {
                new Object[] {
               P00702_A158CliID, P00702_A159CliMatricula, P00702_A160CliNomeFamiliar, P00702_A165CliTipo, P00702_A161CliInsData, P00702_A162CliInsHora, P00702_A163CliInsDataHora, P00702_A164CliInsUserID, P00702_n164CliInsUserID, P00702_A393CliInsUserNome,
               P00702_n393CliInsUserNome, P00702_A177CliiUpdData, P00702_n177CliiUpdData, P00702_A178CliUpdHora, P00702_n178CliUpdHora, P00702_A179CliUpdDataHora, P00702_n179CliUpdDataHora, P00702_A180CliUpdUserID, P00702_n180CliUpdUserID, P00702_A394CliUpdUserNome,
               P00702_n394CliUpdUserNome, P00702_A196CliVersao, P00702_A197CliAtivo, P00702_A524CliDel, P00702_A525CliDelDataHora, P00702_n525CliDelDataHora, P00702_A526CliDelData, P00702_n526CliDelData, P00702_A527CliDelHora, P00702_n527CliDelHora,
               P00702_A528CliDelUsuId, P00702_n528CliDelUsuId, P00702_A529CliDelUsuNome, P00702_n529CliDelUsuNome
               }
               , new Object[] {
               P00703_A158CliID, P00703_A159CliMatricula, P00703_A160CliNomeFamiliar, P00703_A165CliTipo, P00703_A161CliInsData, P00703_A162CliInsHora, P00703_A163CliInsDataHora, P00703_A164CliInsUserID, P00703_n164CliInsUserID, P00703_A393CliInsUserNome,
               P00703_n393CliInsUserNome, P00703_A177CliiUpdData, P00703_n177CliiUpdData, P00703_A178CliUpdHora, P00703_n178CliUpdHora, P00703_A179CliUpdDataHora, P00703_n179CliUpdDataHora, P00703_A180CliUpdUserID, P00703_n180CliUpdUserID, P00703_A394CliUpdUserNome,
               P00703_n394CliUpdUserNome, P00703_A196CliVersao, P00703_A197CliAtivo, P00703_A524CliDel, P00703_A525CliDelDataHora, P00703_n525CliDelDataHora, P00703_A526CliDelData, P00703_n526CliDelData, P00703_A527CliDelHora, P00703_n527CliDelHora,
               P00703_A528CliDelUsuId, P00703_n528CliDelUsuId, P00703_A529CliDelUsuNome, P00703_n529CliDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A165CliTipo ;
      private short A196CliVersao ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private long A159CliMatricula ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A164CliInsUserID ;
      private string A180CliUpdUserID ;
      private string A528CliDelUsuId ;
      private DateTime A162CliInsHora ;
      private DateTime A163CliInsDataHora ;
      private DateTime A178CliUpdHora ;
      private DateTime A179CliUpdDataHora ;
      private DateTime A525CliDelDataHora ;
      private DateTime A526CliDelData ;
      private DateTime A527CliDelHora ;
      private DateTime A161CliInsData ;
      private DateTime A177CliiUpdData ;
      private bool returnInSub ;
      private bool n164CliInsUserID ;
      private bool n393CliInsUserNome ;
      private bool n177CliiUpdData ;
      private bool n178CliUpdHora ;
      private bool n179CliUpdDataHora ;
      private bool n180CliUpdUserID ;
      private bool n394CliUpdUserNome ;
      private bool A197CliAtivo ;
      private bool A524CliDel ;
      private bool n525CliDelDataHora ;
      private bool n526CliDelData ;
      private bool n527CliDelHora ;
      private bool n528CliDelUsuId ;
      private bool n529CliDelUsuNome ;
      private string A160CliNomeFamiliar ;
      private string A393CliInsUserNome ;
      private string A394CliUpdUserNome ;
      private string A529CliDelUsuNome ;
      private Guid AV17CliID ;
      private Guid A158CliID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00702_A158CliID ;
      private long[] P00702_A159CliMatricula ;
      private string[] P00702_A160CliNomeFamiliar ;
      private short[] P00702_A165CliTipo ;
      private DateTime[] P00702_A161CliInsData ;
      private DateTime[] P00702_A162CliInsHora ;
      private DateTime[] P00702_A163CliInsDataHora ;
      private string[] P00702_A164CliInsUserID ;
      private bool[] P00702_n164CliInsUserID ;
      private string[] P00702_A393CliInsUserNome ;
      private bool[] P00702_n393CliInsUserNome ;
      private DateTime[] P00702_A177CliiUpdData ;
      private bool[] P00702_n177CliiUpdData ;
      private DateTime[] P00702_A178CliUpdHora ;
      private bool[] P00702_n178CliUpdHora ;
      private DateTime[] P00702_A179CliUpdDataHora ;
      private bool[] P00702_n179CliUpdDataHora ;
      private string[] P00702_A180CliUpdUserID ;
      private bool[] P00702_n180CliUpdUserID ;
      private string[] P00702_A394CliUpdUserNome ;
      private bool[] P00702_n394CliUpdUserNome ;
      private short[] P00702_A196CliVersao ;
      private bool[] P00702_A197CliAtivo ;
      private bool[] P00702_A524CliDel ;
      private DateTime[] P00702_A525CliDelDataHora ;
      private bool[] P00702_n525CliDelDataHora ;
      private DateTime[] P00702_A526CliDelData ;
      private bool[] P00702_n526CliDelData ;
      private DateTime[] P00702_A527CliDelHora ;
      private bool[] P00702_n527CliDelHora ;
      private string[] P00702_A528CliDelUsuId ;
      private bool[] P00702_n528CliDelUsuId ;
      private string[] P00702_A529CliDelUsuNome ;
      private bool[] P00702_n529CliDelUsuNome ;
      private Guid[] P00703_A158CliID ;
      private long[] P00703_A159CliMatricula ;
      private string[] P00703_A160CliNomeFamiliar ;
      private short[] P00703_A165CliTipo ;
      private DateTime[] P00703_A161CliInsData ;
      private DateTime[] P00703_A162CliInsHora ;
      private DateTime[] P00703_A163CliInsDataHora ;
      private string[] P00703_A164CliInsUserID ;
      private bool[] P00703_n164CliInsUserID ;
      private string[] P00703_A393CliInsUserNome ;
      private bool[] P00703_n393CliInsUserNome ;
      private DateTime[] P00703_A177CliiUpdData ;
      private bool[] P00703_n177CliiUpdData ;
      private DateTime[] P00703_A178CliUpdHora ;
      private bool[] P00703_n178CliUpdHora ;
      private DateTime[] P00703_A179CliUpdDataHora ;
      private bool[] P00703_n179CliUpdDataHora ;
      private string[] P00703_A180CliUpdUserID ;
      private bool[] P00703_n180CliUpdUserID ;
      private string[] P00703_A394CliUpdUserNome ;
      private bool[] P00703_n394CliUpdUserNome ;
      private short[] P00703_A196CliVersao ;
      private bool[] P00703_A197CliAtivo ;
      private bool[] P00703_A524CliDel ;
      private DateTime[] P00703_A525CliDelDataHora ;
      private bool[] P00703_n525CliDelDataHora ;
      private DateTime[] P00703_A526CliDelData ;
      private bool[] P00703_n526CliDelData ;
      private DateTime[] P00703_A527CliDelHora ;
      private bool[] P00703_n527CliDelHora ;
      private string[] P00703_A528CliDelUsuId ;
      private bool[] P00703_n528CliDelUsuId ;
      private string[] P00703_A529CliDelUsuNome ;
      private bool[] P00703_n529CliDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditcliente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00702;
          prmP00702 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00703;
          prmP00703 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00702", "SELECT CliID, CliMatricula, CliNomeFamiliar, CliTipo, CliInsData, CliInsHora, CliInsDataHora, CliInsUserID, CliInsUserNome, CliiUpdData, CliUpdHora, CliUpdDataHora, CliUpdUserID, CliUpdUserNome, CliVersao, CliAtivo, CliDel, CliDelDataHora, CliDelData, CliDelHora, CliDelUsuId, CliDelUsuNome FROM tb_cliente WHERE CliID = :AV17CliID ORDER BY CliID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00702,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00703", "SELECT CliID, CliMatricula, CliNomeFamiliar, CliTipo, CliInsData, CliInsHora, CliInsDataHora, CliInsUserID, CliInsUserNome, CliiUpdData, CliUpdHora, CliUpdDataHora, CliUpdUserID, CliUpdUserNome, CliVersao, CliAtivo, CliDel, CliDelDataHora, CliDelData, CliDelHora, CliDelUsuId, CliDelUsuNome FROM tb_cliente WHERE CliID = :AV17CliID ORDER BY CliID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00703,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
                ((string[]) buf[7])[0] = rslt.getString(8, 40);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12, true);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getString(13, 40);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((string[]) buf[19])[0] = rslt.getVarchar(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((short[]) buf[21])[0] = rslt.getShort(15);
                ((bool[]) buf[22])[0] = rslt.getBool(16);
                ((bool[]) buf[23])[0] = rslt.getBool(17);
                ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[29])[0] = rslt.wasNull(20);
                ((string[]) buf[30])[0] = rslt.getString(21, 40);
                ((bool[]) buf[31])[0] = rslt.wasNull(21);
                ((string[]) buf[32])[0] = rslt.getVarchar(22);
                ((bool[]) buf[33])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
                ((string[]) buf[7])[0] = rslt.getString(8, 40);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12, true);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getString(13, 40);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((string[]) buf[19])[0] = rslt.getVarchar(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((short[]) buf[21])[0] = rslt.getShort(15);
                ((bool[]) buf[22])[0] = rslt.getBool(16);
                ((bool[]) buf[23])[0] = rslt.getBool(17);
                ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(20);
                ((bool[]) buf[29])[0] = rslt.wasNull(20);
                ((string[]) buf[30])[0] = rslt.getString(21, 40);
                ((bool[]) buf[31])[0] = rslt.wasNull(21);
                ((string[]) buf[32])[0] = rslt.getVarchar(22);
                ((bool[]) buf[33])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

}
