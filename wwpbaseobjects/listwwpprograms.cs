using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class listwwpprograms : GXProcedure
   {
      public listwwpprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listwwpprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         listwwpprograms objlistwwpprograms;
         objlistwwpprograms = new listwwpprograms();
         objlistwwpprograms.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "agl_tresorygroup") ;
         objlistwwpprograms.context.SetSubmitInitialConfig(context);
         objlistwwpprograms.initialize();
         Submit( executePrivateCatch,objlistwwpprograms);
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listwwpprograms)stateInfo).executePrivate();
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
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "agl_tresorygroup");
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV13name = "core.regiaoWW";
         AV14description = " Regiões";
         AV15link = formatLink("core.regiaoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.DocumentoTipoWW";
         AV14description = " Tipo de Documento";
         AV15link = formatLink("core.documentotipoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWAuthTypes";
         AV14description = "Tipos de autenticação";
         AV15link = formatLink("gamwwauthtypes.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.GeneroWW";
         AV14description = " Genero da Pessoa";
         AV15link = formatLink("core.generoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ClienteWW";
         AV14description = " Cliente";
         AV15link = formatLink("core.clienteww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.IteracaoWW";
         AV14description = " Iterações";
         AV15link = formatLink("core.iteracaoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWSecurityPolicy";
         AV14description = "Políticas de segurança";
         AV15link = formatLink("gamwwsecuritypolicy.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWConnections";
         AV14description = "Conexões";
         AV15link = formatLink("gamwwconnections.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ClientePJTipoWW";
         AV14description = " Tipo de Cliente PJ";
         AV15link = formatLink("core.clientepjtipoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.AuditWW";
         AV14description = " Auditoria dos Dados";
         AV15link = formatLink("core.auditww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWApplications";
         AV14description = "Aplicações";
         AV15link = formatLink("gamwwapplications.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.VisitaTipoWW";
         AV14description = " Tipos de Visita";
         AV15link = formatLink("core.visitatipoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.TabelaDePrecoWW";
         AV14description = " Tabela de Preço do Produto ou Serviço";
         AV15link = formatLink("core.tabeladeprecoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ufWW";
         AV14description = " UFs (Unidades Federativas)";
         AV15link = formatLink("core.ufww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ParametrosWW";
         AV14description = " Parâmetros";
         AV15link = formatLink("core.parametrosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWRepositories";
         AV14description = "Repositórios";
         AV15link = formatLink("gamwwrepositories.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.CentroDeCustoWW";
         AV14description = " Centro De Custo";
         AV15link = formatLink("core.centrodecustoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.municipioWW";
         AV14description = " Município";
         AV15link = formatLink("core.municipioww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         AV14description = "Visualize all notifications";
         AV15link = formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ClientePJContatoWW";
         AV14description = " Contato";
         AV15link = formatLink("core.clientepjcontatoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWEventSubscriptions";
         AV14description = "Subscrições a eventos";
         AV15link = formatLink("gamwweventsubscriptions.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.mesorregiaoWW";
         AV14description = " Mesorregiões";
         AV15link = formatLink("core.mesorregiaoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         AV14description = "Manage my Subscriptions";
         AV15link = formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.webfunil";
         AV14description = "Funil de Vendas";
         AV15link = formatLink("core.webfunil.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.NegocioPJWW";
         AV14description = "Oportunidades de Negócio";
         AV15link = formatLink("core.negociopjww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ProdutoWW";
         AV14description = " Produto ou Serviço";
         AV15link = formatLink("core.produtoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWRoles";
         AV14description = "Perfis";
         AV15link = formatLink("gamwwroles.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ContatoTipoWW";
         AV14description = " Tipo de Contato";
         AV15link = formatLink("core.contatotipoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.ProdutoTipoWW";
         AV14description = " Tipo de Produto";
         AV15link = formatLink("core.produtotipoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "core.microrregiaoWW";
         AV14description = " Microrregião";
         AV15link = formatLink("core.microrregiaoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13name = "GAMWWUsers";
         AV14description = "Usuários";
         AV15link = formatLink("gamwwusers.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         AV8IsAuthorized = true;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV13name;
            AV10ProgramName.gxTpr_Description = AV14description;
            AV10ProgramName.gxTpr_Link = AV15link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
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
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "agl_tresorygroup");
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13name = "";
         AV14description = "";
         AV15link = "";
         AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private string AV13name ;
      private string AV14description ;
      private string AV15link ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> AV9ProgramNames ;
      private GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName AV10ProgramName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
   }

}
