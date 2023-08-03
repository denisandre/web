using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   [XmlRoot(ElementName = "NegocioPJEstrutura" )]
   [XmlType(TypeName =  "NegocioPJEstrutura" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtNegocioPJEstrutura : GxSilentTrnSdt
   {
      public SdtNegocioPJEstrutura( )
      {
      }

      public SdtNegocioPJEstrutura( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV345NegID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV345NegID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NegID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\NegocioPJEstrutura");
         metadata.Set("BT", "tb_negociopj");
         metadata.Set("PK", "[ \"NegID\" ]");
         metadata.Set("PKAssigned", "[ \"NegID\" ]");
         metadata.Set("Levels", "[ \"Fase\",\"Item\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"tb_negociopj\",\"NegUltFase\",\"NgfSeq\",\"NegID\",\"NegID\" ],[ \"Same\",\"tb_negociopj\",\"NegUltItem\",\"NgpItem\",\"NegID\",\"NegID\" ] ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CliID\",\"CpjID\",\"CpjEndSeq\" ],\"FKMap\":[ \"NegCliID-CliID\",\"NegCpjID-CpjID\",\"NegCpjEndSeq-CpjEndSeq\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Negid_Z");
         state.Add("gxTpr_Negcodigo_Z");
         state.Add("gxTpr_Neginsdata_Z_Nullable");
         state.Add("gxTpr_Neginshora_Z_Nullable");
         state.Add("gxTpr_Neginsdatahora_Z_Nullable");
         state.Add("gxTpr_Neginsusuid_Z");
         state.Add("gxTpr_Neginsusunome_Z");
         state.Add("gxTpr_Negcliid_Z");
         state.Add("gxTpr_Negclimatricula_Z");
         state.Add("gxTpr_Negclinomefamiliar_Z");
         state.Add("gxTpr_Negcpjid_Z");
         state.Add("gxTpr_Negcpjnomfan_Z");
         state.Add("gxTpr_Negcpjrazsocial_Z");
         state.Add("gxTpr_Negcpjmatricula_Z");
         state.Add("gxTpr_Negpjtid_Z");
         state.Add("gxTpr_Negpjtsigla_Z");
         state.Add("gxTpr_Negpjtnome_Z");
         state.Add("gxTpr_Negcpjendseq_Z");
         state.Add("gxTpr_Negcpjendnome_Z");
         state.Add("gxTpr_Negcpjendendereco_Z");
         state.Add("gxTpr_Negcpjendnumero_Z");
         state.Add("gxTpr_Negcpjendcomplem_Z");
         state.Add("gxTpr_Negcpjendbairro_Z");
         state.Add("gxTpr_Negcpjendmunid_Z");
         state.Add("gxTpr_Negcpjendmunnome_Z");
         state.Add("gxTpr_Negcpjendufid_Z");
         state.Add("gxTpr_Negcpjendufsigla_Z");
         state.Add("gxTpr_Negcpjendufnome_Z");
         state.Add("gxTpr_Negagcid_Z");
         state.Add("gxTpr_Negagcnome_Z");
         state.Add("gxTpr_Negassunto_Z");
         state.Add("gxTpr_Negultfase_Z");
         state.Add("gxTpr_Negultngfseq_Z");
         state.Add("gxTpr_Negultiteid_Z");
         state.Add("gxTpr_Negultitenome_Z");
         state.Add("gxTpr_Negultiteordem_Z");
         state.Add("gxTpr_Negpgptotal_Z");
         state.Add("gxTpr_Negvalorestimado_Z");
         state.Add("gxTpr_Negvaloratualizado_Z");
         state.Add("gxTpr_Negultitem_Z");
         state.Add("gxTpr_Negdel_Z");
         state.Add("gxTpr_Negdeldatahora_Z_Nullable");
         state.Add("gxTpr_Negdeldata_Z_Nullable");
         state.Add("gxTpr_Negdelhora_Z_Nullable");
         state.Add("gxTpr_Negdelusuid_Z");
         state.Add("gxTpr_Negdelusunome_Z");
         state.Add("gxTpr_Neginsusuid_N");
         state.Add("gxTpr_Neginsusunome_N");
         state.Add("gxTpr_Negcpjendcomplem_N");
         state.Add("gxTpr_Negagcid_N");
         state.Add("gxTpr_Negagcnome_N");
         state.Add("gxTpr_Negultngfseq_N");
         state.Add("gxTpr_Negultiteid_N");
         state.Add("gxTpr_Negultitenome_N");
         state.Add("gxTpr_Negultiteordem_N");
         state.Add("gxTpr_Negpgptotal_N");
         state.Add("gxTpr_Negultitem_N");
         state.Add("gxTpr_Negdeldatahora_N");
         state.Add("gxTpr_Negdeldata_N");
         state.Add("gxTpr_Negdelhora_N");
         state.Add("gxTpr_Negdelusuid_N");
         state.Add("gxTpr_Negdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtNegocioPJEstrutura sdt;
         sdt = (GeneXus.Programs.core.SdtNegocioPJEstrutura)(source);
         gxTv_SdtNegocioPJEstrutura_Negid = sdt.gxTv_SdtNegocioPJEstrutura_Negid ;
         gxTv_SdtNegocioPJEstrutura_Negcodigo = sdt.gxTv_SdtNegocioPJEstrutura_Negcodigo ;
         gxTv_SdtNegocioPJEstrutura_Neginsdata = sdt.gxTv_SdtNegocioPJEstrutura_Neginsdata ;
         gxTv_SdtNegocioPJEstrutura_Neginshora = sdt.gxTv_SdtNegocioPJEstrutura_Neginshora ;
         gxTv_SdtNegocioPJEstrutura_Neginsdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Neginsdatahora ;
         gxTv_SdtNegocioPJEstrutura_Neginsusuid = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusuid ;
         gxTv_SdtNegocioPJEstrutura_Neginsusunome = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusunome ;
         gxTv_SdtNegocioPJEstrutura_Negcliid = sdt.gxTv_SdtNegocioPJEstrutura_Negcliid ;
         gxTv_SdtNegocioPJEstrutura_Negclimatricula = sdt.gxTv_SdtNegocioPJEstrutura_Negclimatricula ;
         gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar = sdt.gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar ;
         gxTv_SdtNegocioPJEstrutura_Negcpjid = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjid ;
         gxTv_SdtNegocioPJEstrutura_Negcpjnomfan = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjnomfan ;
         gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial ;
         gxTv_SdtNegocioPJEstrutura_Negcpjmatricula = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjmatricula ;
         gxTv_SdtNegocioPJEstrutura_Negpjtid = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtid ;
         gxTv_SdtNegocioPJEstrutura_Negpjtsigla = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtsigla ;
         gxTv_SdtNegocioPJEstrutura_Negpjtnome = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtnome ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendseq = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendseq ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendnome = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendnome ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendendereco = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendendereco ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendnumero = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendnumero ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendbairro = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendbairro ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunid = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendmunid ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendufid = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufid ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendufnome = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufnome ;
         gxTv_SdtNegocioPJEstrutura_Negagcid = sdt.gxTv_SdtNegocioPJEstrutura_Negagcid ;
         gxTv_SdtNegocioPJEstrutura_Negagcnome = sdt.gxTv_SdtNegocioPJEstrutura_Negagcnome ;
         gxTv_SdtNegocioPJEstrutura_Negassunto = sdt.gxTv_SdtNegocioPJEstrutura_Negassunto ;
         gxTv_SdtNegocioPJEstrutura_Negdescricao = sdt.gxTv_SdtNegocioPJEstrutura_Negdescricao ;
         gxTv_SdtNegocioPJEstrutura_Negultfase = sdt.gxTv_SdtNegocioPJEstrutura_Negultfase ;
         gxTv_SdtNegocioPJEstrutura_Negultngfseq = sdt.gxTv_SdtNegocioPJEstrutura_Negultngfseq ;
         gxTv_SdtNegocioPJEstrutura_Negultiteid = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteid ;
         gxTv_SdtNegocioPJEstrutura_Negultitenome = sdt.gxTv_SdtNegocioPJEstrutura_Negultitenome ;
         gxTv_SdtNegocioPJEstrutura_Negultiteordem = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteordem ;
         gxTv_SdtNegocioPJEstrutura_Negpgptotal = sdt.gxTv_SdtNegocioPJEstrutura_Negpgptotal ;
         gxTv_SdtNegocioPJEstrutura_Negvalorestimado = sdt.gxTv_SdtNegocioPJEstrutura_Negvalorestimado ;
         gxTv_SdtNegocioPJEstrutura_Negvaloratualizado = sdt.gxTv_SdtNegocioPJEstrutura_Negvaloratualizado ;
         gxTv_SdtNegocioPJEstrutura_Negultitem = sdt.gxTv_SdtNegocioPJEstrutura_Negultitem ;
         gxTv_SdtNegocioPJEstrutura_Negdel = sdt.gxTv_SdtNegocioPJEstrutura_Negdel ;
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldatahora ;
         gxTv_SdtNegocioPJEstrutura_Negdeldata = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldata ;
         gxTv_SdtNegocioPJEstrutura_Negdelhora = sdt.gxTv_SdtNegocioPJEstrutura_Negdelhora ;
         gxTv_SdtNegocioPJEstrutura_Negdelusuid = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusuid ;
         gxTv_SdtNegocioPJEstrutura_Negdelusunome = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusunome ;
         gxTv_SdtNegocioPJEstrutura_Fase = sdt.gxTv_SdtNegocioPJEstrutura_Fase ;
         gxTv_SdtNegocioPJEstrutura_Item = sdt.gxTv_SdtNegocioPJEstrutura_Item ;
         gxTv_SdtNegocioPJEstrutura_Mode = sdt.gxTv_SdtNegocioPJEstrutura_Mode ;
         gxTv_SdtNegocioPJEstrutura_Initialized = sdt.gxTv_SdtNegocioPJEstrutura_Initialized ;
         gxTv_SdtNegocioPJEstrutura_Negid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcodigo_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcodigo_Z ;
         gxTv_SdtNegocioPJEstrutura_Neginsdata_Z = sdt.gxTv_SdtNegocioPJEstrutura_Neginsdata_Z ;
         gxTv_SdtNegocioPJEstrutura_Neginshora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Neginshora_Z ;
         gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z ;
         gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z ;
         gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcliid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcliid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z ;
         gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z ;
         gxTv_SdtNegocioPJEstrutura_Negpjtid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z ;
         gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z ;
         gxTv_SdtNegocioPJEstrutura_Negagcid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negagcid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negagcnome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negagcnome_Z ;
         gxTv_SdtNegocioPJEstrutura_Negassunto_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negassunto_Z ;
         gxTv_SdtNegocioPJEstrutura_Negultfase_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negultfase_Z ;
         gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z ;
         gxTv_SdtNegocioPJEstrutura_Negultiteid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negultitenome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negultitenome_Z ;
         gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z ;
         gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z ;
         gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z ;
         gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z ;
         gxTv_SdtNegocioPJEstrutura_Negultitem_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negultitem_Z ;
         gxTv_SdtNegocioPJEstrutura_Negdel_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negdel_Z ;
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z ;
         gxTv_SdtNegocioPJEstrutura_Negdeldata_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldata_Z ;
         gxTv_SdtNegocioPJEstrutura_Negdelhora_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negdelhora_Z ;
         gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z ;
         gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z ;
         gxTv_SdtNegocioPJEstrutura_Neginsusuid_N = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusuid_N ;
         gxTv_SdtNegocioPJEstrutura_Neginsusunome_N = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusunome_N ;
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N ;
         gxTv_SdtNegocioPJEstrutura_Negagcid_N = sdt.gxTv_SdtNegocioPJEstrutura_Negagcid_N ;
         gxTv_SdtNegocioPJEstrutura_Negagcnome_N = sdt.gxTv_SdtNegocioPJEstrutura_Negagcnome_N ;
         gxTv_SdtNegocioPJEstrutura_Negultngfseq_N = sdt.gxTv_SdtNegocioPJEstrutura_Negultngfseq_N ;
         gxTv_SdtNegocioPJEstrutura_Negultiteid_N = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteid_N ;
         gxTv_SdtNegocioPJEstrutura_Negultitenome_N = sdt.gxTv_SdtNegocioPJEstrutura_Negultitenome_N ;
         gxTv_SdtNegocioPJEstrutura_Negultiteordem_N = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteordem_N ;
         gxTv_SdtNegocioPJEstrutura_Negpgptotal_N = sdt.gxTv_SdtNegocioPJEstrutura_Negpgptotal_N ;
         gxTv_SdtNegocioPJEstrutura_Negultitem_N = sdt.gxTv_SdtNegocioPJEstrutura_Negultitem_N ;
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N ;
         gxTv_SdtNegocioPJEstrutura_Negdeldata_N = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldata_N ;
         gxTv_SdtNegocioPJEstrutura_Negdelhora_N = sdt.gxTv_SdtNegocioPJEstrutura_Negdelhora_N ;
         gxTv_SdtNegocioPJEstrutura_Negdelusuid_N = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusuid_N ;
         gxTv_SdtNegocioPJEstrutura_Negdelusunome_N = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusunome_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("NegID", gxTv_SdtNegocioPJEstrutura_Negid, false, includeNonInitialized);
         AddObjectProperty("NegCodigo", gxTv_SdtNegocioPJEstrutura_Negcodigo, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Neginsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Neginsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Neginsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NegInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Neginshora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NegInsHora", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Neginsdatahora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NegInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NegInsUsuID", gxTv_SdtNegocioPJEstrutura_Neginsusuid, false, includeNonInitialized);
         AddObjectProperty("NegInsUsuID_N", gxTv_SdtNegocioPJEstrutura_Neginsusuid_N, false, includeNonInitialized);
         AddObjectProperty("NegInsUsuNome", gxTv_SdtNegocioPJEstrutura_Neginsusunome, false, includeNonInitialized);
         AddObjectProperty("NegInsUsuNome_N", gxTv_SdtNegocioPJEstrutura_Neginsusunome_N, false, includeNonInitialized);
         AddObjectProperty("NegCliID", gxTv_SdtNegocioPJEstrutura_Negcliid, false, includeNonInitialized);
         AddObjectProperty("NegCliMatricula", gxTv_SdtNegocioPJEstrutura_Negclimatricula, false, includeNonInitialized);
         AddObjectProperty("NegCliNomeFamiliar", gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar, false, includeNonInitialized);
         AddObjectProperty("NegCpjID", gxTv_SdtNegocioPJEstrutura_Negcpjid, false, includeNonInitialized);
         AddObjectProperty("NegCpjNomFan", gxTv_SdtNegocioPJEstrutura_Negcpjnomfan, false, includeNonInitialized);
         AddObjectProperty("NegCpjRazSocial", gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial, false, includeNonInitialized);
         AddObjectProperty("NegCpjMatricula", gxTv_SdtNegocioPJEstrutura_Negcpjmatricula, false, includeNonInitialized);
         AddObjectProperty("NegPjtID", gxTv_SdtNegocioPJEstrutura_Negpjtid, false, includeNonInitialized);
         AddObjectProperty("NegPjtSigla", gxTv_SdtNegocioPJEstrutura_Negpjtsigla, false, includeNonInitialized);
         AddObjectProperty("NegPjtNome", gxTv_SdtNegocioPJEstrutura_Negpjtnome, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndSeq", gxTv_SdtNegocioPJEstrutura_Negcpjendseq, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndNome", gxTv_SdtNegocioPJEstrutura_Negcpjendnome, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndEndereco", gxTv_SdtNegocioPJEstrutura_Negcpjendendereco, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndNumero", gxTv_SdtNegocioPJEstrutura_Negcpjendnumero, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndComplem", gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndComplem_N", gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndBairro", gxTv_SdtNegocioPJEstrutura_Negcpjendbairro, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndMunID", gxTv_SdtNegocioPJEstrutura_Negcpjendmunid, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndMunNome", gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndUFID", gxTv_SdtNegocioPJEstrutura_Negcpjendufid, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndUFSigla", gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla, false, includeNonInitialized);
         AddObjectProperty("NegCpjEndUFNome", gxTv_SdtNegocioPJEstrutura_Negcpjendufnome, false, includeNonInitialized);
         AddObjectProperty("NegAgcID", gxTv_SdtNegocioPJEstrutura_Negagcid, false, includeNonInitialized);
         AddObjectProperty("NegAgcID_N", gxTv_SdtNegocioPJEstrutura_Negagcid_N, false, includeNonInitialized);
         AddObjectProperty("NegAgcNome", gxTv_SdtNegocioPJEstrutura_Negagcnome, false, includeNonInitialized);
         AddObjectProperty("NegAgcNome_N", gxTv_SdtNegocioPJEstrutura_Negagcnome_N, false, includeNonInitialized);
         AddObjectProperty("NegAssunto", gxTv_SdtNegocioPJEstrutura_Negassunto, false, includeNonInitialized);
         AddObjectProperty("NegDescricao", gxTv_SdtNegocioPJEstrutura_Negdescricao, false, includeNonInitialized);
         AddObjectProperty("NegUltFase", gxTv_SdtNegocioPJEstrutura_Negultfase, false, includeNonInitialized);
         AddObjectProperty("NegUltNgfSeq", gxTv_SdtNegocioPJEstrutura_Negultngfseq, false, includeNonInitialized);
         AddObjectProperty("NegUltNgfSeq_N", gxTv_SdtNegocioPJEstrutura_Negultngfseq_N, false, includeNonInitialized);
         AddObjectProperty("NegUltIteID", gxTv_SdtNegocioPJEstrutura_Negultiteid, false, includeNonInitialized);
         AddObjectProperty("NegUltIteID_N", gxTv_SdtNegocioPJEstrutura_Negultiteid_N, false, includeNonInitialized);
         AddObjectProperty("NegUltIteNome", gxTv_SdtNegocioPJEstrutura_Negultitenome, false, includeNonInitialized);
         AddObjectProperty("NegUltIteNome_N", gxTv_SdtNegocioPJEstrutura_Negultitenome_N, false, includeNonInitialized);
         AddObjectProperty("NegUltIteOrdem", gxTv_SdtNegocioPJEstrutura_Negultiteordem, false, includeNonInitialized);
         AddObjectProperty("NegUltIteOrdem_N", gxTv_SdtNegocioPJEstrutura_Negultiteordem_N, false, includeNonInitialized);
         AddObjectProperty("NegPgpTotal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Negpgptotal, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("NegPgpTotal_N", gxTv_SdtNegocioPJEstrutura_Negpgptotal_N, false, includeNonInitialized);
         AddObjectProperty("NegValorEstimado", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Negvalorestimado, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("NegValorAtualizado", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Negvaloratualizado, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("NegUltItem", gxTv_SdtNegocioPJEstrutura_Negultitem, false, includeNonInitialized);
         AddObjectProperty("NegUltItem_N", gxTv_SdtNegocioPJEstrutura_Negultitem_N, false, includeNonInitialized);
         AddObjectProperty("NegDel", gxTv_SdtNegocioPJEstrutura_Negdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Negdeldatahora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NegDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NegDelDataHora_N", gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Negdeldata;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NegDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NegDelData_N", gxTv_SdtNegocioPJEstrutura_Negdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNegocioPJEstrutura_Negdelhora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("NegDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NegDelHora_N", gxTv_SdtNegocioPJEstrutura_Negdelhora_N, false, includeNonInitialized);
         AddObjectProperty("NegDelUsuId", gxTv_SdtNegocioPJEstrutura_Negdelusuid, false, includeNonInitialized);
         AddObjectProperty("NegDelUsuId_N", gxTv_SdtNegocioPJEstrutura_Negdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("NegDelUsuNome", gxTv_SdtNegocioPJEstrutura_Negdelusunome, false, includeNonInitialized);
         AddObjectProperty("NegDelUsuNome_N", gxTv_SdtNegocioPJEstrutura_Negdelusunome_N, false, includeNonInitialized);
         if ( gxTv_SdtNegocioPJEstrutura_Fase != null )
         {
            AddObjectProperty("Fase", gxTv_SdtNegocioPJEstrutura_Fase, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtNegocioPJEstrutura_Item != null )
         {
            AddObjectProperty("Item", gxTv_SdtNegocioPJEstrutura_Item, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNegocioPJEstrutura_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNegocioPJEstrutura_Initialized, false, includeNonInitialized);
            AddObjectProperty("NegID_Z", gxTv_SdtNegocioPJEstrutura_Negid_Z, false, includeNonInitialized);
            AddObjectProperty("NegCodigo_Z", gxTv_SdtNegocioPJEstrutura_Negcodigo_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtNegocioPJEstrutura_Neginsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtNegocioPJEstrutura_Neginsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtNegocioPJEstrutura_Neginsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NegInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Neginshora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NegInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NegInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NegInsUsuID_Z", gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NegInsUsuNome_Z", gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NegCliID_Z", gxTv_SdtNegocioPJEstrutura_Negcliid_Z, false, includeNonInitialized);
            AddObjectProperty("NegCliMatricula_Z", gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z, false, includeNonInitialized);
            AddObjectProperty("NegCliNomeFamiliar_Z", gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjID_Z", gxTv_SdtNegocioPJEstrutura_Negcpjid_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjNomFan_Z", gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjRazSocial_Z", gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjMatricula_Z", gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z, false, includeNonInitialized);
            AddObjectProperty("NegPjtID_Z", gxTv_SdtNegocioPJEstrutura_Negpjtid_Z, false, includeNonInitialized);
            AddObjectProperty("NegPjtSigla_Z", gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z, false, includeNonInitialized);
            AddObjectProperty("NegPjtNome_Z", gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndSeq_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndNome_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndEndereco_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndNumero_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndComplem_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndBairro_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndMunID_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndMunNome_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndUFID_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndUFSigla_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndUFNome_Z", gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z, false, includeNonInitialized);
            AddObjectProperty("NegAgcID_Z", gxTv_SdtNegocioPJEstrutura_Negagcid_Z, false, includeNonInitialized);
            AddObjectProperty("NegAgcNome_Z", gxTv_SdtNegocioPJEstrutura_Negagcnome_Z, false, includeNonInitialized);
            AddObjectProperty("NegAssunto_Z", gxTv_SdtNegocioPJEstrutura_Negassunto_Z, false, includeNonInitialized);
            AddObjectProperty("NegUltFase_Z", gxTv_SdtNegocioPJEstrutura_Negultfase_Z, false, includeNonInitialized);
            AddObjectProperty("NegUltNgfSeq_Z", gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z, false, includeNonInitialized);
            AddObjectProperty("NegUltIteID_Z", gxTv_SdtNegocioPJEstrutura_Negultiteid_Z, false, includeNonInitialized);
            AddObjectProperty("NegUltIteNome_Z", gxTv_SdtNegocioPJEstrutura_Negultitenome_Z, false, includeNonInitialized);
            AddObjectProperty("NegUltIteOrdem_Z", gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z, false, includeNonInitialized);
            AddObjectProperty("NegPgpTotal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("NegValorEstimado_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("NegValorAtualizado_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("NegUltItem_Z", gxTv_SdtNegocioPJEstrutura_Negultitem_Z, false, includeNonInitialized);
            AddObjectProperty("NegDel_Z", gxTv_SdtNegocioPJEstrutura_Negdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NegDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Negdeldata_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NegDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNegocioPJEstrutura_Negdelhora_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("NegDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NegDelUsuId_Z", gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("NegDelUsuNome_Z", gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("NegInsUsuID_N", gxTv_SdtNegocioPJEstrutura_Neginsusuid_N, false, includeNonInitialized);
            AddObjectProperty("NegInsUsuNome_N", gxTv_SdtNegocioPJEstrutura_Neginsusunome_N, false, includeNonInitialized);
            AddObjectProperty("NegCpjEndComplem_N", gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N, false, includeNonInitialized);
            AddObjectProperty("NegAgcID_N", gxTv_SdtNegocioPJEstrutura_Negagcid_N, false, includeNonInitialized);
            AddObjectProperty("NegAgcNome_N", gxTv_SdtNegocioPJEstrutura_Negagcnome_N, false, includeNonInitialized);
            AddObjectProperty("NegUltNgfSeq_N", gxTv_SdtNegocioPJEstrutura_Negultngfseq_N, false, includeNonInitialized);
            AddObjectProperty("NegUltIteID_N", gxTv_SdtNegocioPJEstrutura_Negultiteid_N, false, includeNonInitialized);
            AddObjectProperty("NegUltIteNome_N", gxTv_SdtNegocioPJEstrutura_Negultitenome_N, false, includeNonInitialized);
            AddObjectProperty("NegUltIteOrdem_N", gxTv_SdtNegocioPJEstrutura_Negultiteordem_N, false, includeNonInitialized);
            AddObjectProperty("NegPgpTotal_N", gxTv_SdtNegocioPJEstrutura_Negpgptotal_N, false, includeNonInitialized);
            AddObjectProperty("NegUltItem_N", gxTv_SdtNegocioPJEstrutura_Negultitem_N, false, includeNonInitialized);
            AddObjectProperty("NegDelDataHora_N", gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("NegDelData_N", gxTv_SdtNegocioPJEstrutura_Negdeldata_N, false, includeNonInitialized);
            AddObjectProperty("NegDelHora_N", gxTv_SdtNegocioPJEstrutura_Negdelhora_N, false, includeNonInitialized);
            AddObjectProperty("NegDelUsuId_N", gxTv_SdtNegocioPJEstrutura_Negdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("NegDelUsuNome_N", gxTv_SdtNegocioPJEstrutura_Negdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtNegocioPJEstrutura sdt )
      {
         if ( sdt.IsDirty("NegID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negid = sdt.gxTv_SdtNegocioPJEstrutura_Negid ;
         }
         if ( sdt.IsDirty("NegCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcodigo = sdt.gxTv_SdtNegocioPJEstrutura_Negcodigo ;
         }
         if ( sdt.IsDirty("NegInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsdata = sdt.gxTv_SdtNegocioPJEstrutura_Neginsdata ;
         }
         if ( sdt.IsDirty("NegInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginshora = sdt.gxTv_SdtNegocioPJEstrutura_Neginshora ;
         }
         if ( sdt.IsDirty("NegInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsdatahora = sdt.gxTv_SdtNegocioPJEstrutura_Neginsdatahora ;
         }
         if ( sdt.IsDirty("NegInsUsuID") )
         {
            gxTv_SdtNegocioPJEstrutura_Neginsusuid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Neginsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusuid = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusuid ;
         }
         if ( sdt.IsDirty("NegInsUsuNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Neginsusunome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Neginsusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusunome = sdt.gxTv_SdtNegocioPJEstrutura_Neginsusunome ;
         }
         if ( sdt.IsDirty("NegCliID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcliid = sdt.gxTv_SdtNegocioPJEstrutura_Negcliid ;
         }
         if ( sdt.IsDirty("NegCliMatricula") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negclimatricula = sdt.gxTv_SdtNegocioPJEstrutura_Negclimatricula ;
         }
         if ( sdt.IsDirty("NegCliNomeFamiliar") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar = sdt.gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar ;
         }
         if ( sdt.IsDirty("NegCpjID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjid = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjid ;
         }
         if ( sdt.IsDirty("NegCpjNomFan") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjnomfan = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjnomfan ;
         }
         if ( sdt.IsDirty("NegCpjRazSocial") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial ;
         }
         if ( sdt.IsDirty("NegCpjMatricula") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjmatricula = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjmatricula ;
         }
         if ( sdt.IsDirty("NegPjtID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtid = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtid ;
         }
         if ( sdt.IsDirty("NegPjtSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtsigla = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtsigla ;
         }
         if ( sdt.IsDirty("NegPjtNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtnome = sdt.gxTv_SdtNegocioPJEstrutura_Negpjtnome ;
         }
         if ( sdt.IsDirty("NegCpjEndSeq") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendseq = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendseq ;
         }
         if ( sdt.IsDirty("NegCpjEndNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendnome = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendnome ;
         }
         if ( sdt.IsDirty("NegCpjEndEndereco") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendendereco = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendendereco ;
         }
         if ( sdt.IsDirty("NegCpjEndNumero") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendnumero = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendnumero ;
         }
         if ( sdt.IsDirty("NegCpjEndComplem") )
         {
            gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem ;
         }
         if ( sdt.IsDirty("NegCpjEndBairro") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendbairro = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendbairro ;
         }
         if ( sdt.IsDirty("NegCpjEndMunID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendmunid = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendmunid ;
         }
         if ( sdt.IsDirty("NegCpjEndMunNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome ;
         }
         if ( sdt.IsDirty("NegCpjEndUFID") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufid = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufid ;
         }
         if ( sdt.IsDirty("NegCpjEndUFSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla ;
         }
         if ( sdt.IsDirty("NegCpjEndUFNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufnome = sdt.gxTv_SdtNegocioPJEstrutura_Negcpjendufnome ;
         }
         if ( sdt.IsDirty("NegAgcID") )
         {
            gxTv_SdtNegocioPJEstrutura_Negagcid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negagcid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcid = sdt.gxTv_SdtNegocioPJEstrutura_Negagcid ;
         }
         if ( sdt.IsDirty("NegAgcNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Negagcnome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negagcnome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcnome = sdt.gxTv_SdtNegocioPJEstrutura_Negagcnome ;
         }
         if ( sdt.IsDirty("NegAssunto") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negassunto = sdt.gxTv_SdtNegocioPJEstrutura_Negassunto ;
         }
         if ( sdt.IsDirty("NegDescricao") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdescricao = sdt.gxTv_SdtNegocioPJEstrutura_Negdescricao ;
         }
         if ( sdt.IsDirty("NegUltFase") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultfase = sdt.gxTv_SdtNegocioPJEstrutura_Negultfase ;
         }
         if ( sdt.IsDirty("NegUltNgfSeq") )
         {
            gxTv_SdtNegocioPJEstrutura_Negultngfseq_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negultngfseq_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultngfseq = sdt.gxTv_SdtNegocioPJEstrutura_Negultngfseq ;
         }
         if ( sdt.IsDirty("NegUltIteID") )
         {
            gxTv_SdtNegocioPJEstrutura_Negultiteid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negultiteid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteid = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteid ;
         }
         if ( sdt.IsDirty("NegUltIteNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Negultitenome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negultitenome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitenome = sdt.gxTv_SdtNegocioPJEstrutura_Negultitenome ;
         }
         if ( sdt.IsDirty("NegUltIteOrdem") )
         {
            gxTv_SdtNegocioPJEstrutura_Negultiteordem_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negultiteordem_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteordem = sdt.gxTv_SdtNegocioPJEstrutura_Negultiteordem ;
         }
         if ( sdt.IsDirty("NegPgpTotal") )
         {
            gxTv_SdtNegocioPJEstrutura_Negpgptotal_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negpgptotal_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpgptotal = sdt.gxTv_SdtNegocioPJEstrutura_Negpgptotal ;
         }
         if ( sdt.IsDirty("NegValorEstimado") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negvalorestimado = sdt.gxTv_SdtNegocioPJEstrutura_Negvalorestimado ;
         }
         if ( sdt.IsDirty("NegValorAtualizado") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negvaloratualizado = sdt.gxTv_SdtNegocioPJEstrutura_Negvaloratualizado ;
         }
         if ( sdt.IsDirty("NegUltItem") )
         {
            gxTv_SdtNegocioPJEstrutura_Negultitem_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negultitem_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitem = sdt.gxTv_SdtNegocioPJEstrutura_Negultitem ;
         }
         if ( sdt.IsDirty("NegDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdel = sdt.gxTv_SdtNegocioPJEstrutura_Negdel ;
         }
         if ( sdt.IsDirty("NegDelDataHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldatahora = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldatahora ;
         }
         if ( sdt.IsDirty("NegDelData") )
         {
            gxTv_SdtNegocioPJEstrutura_Negdeldata_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldata = sdt.gxTv_SdtNegocioPJEstrutura_Negdeldata ;
         }
         if ( sdt.IsDirty("NegDelHora") )
         {
            gxTv_SdtNegocioPJEstrutura_Negdelhora_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelhora = sdt.gxTv_SdtNegocioPJEstrutura_Negdelhora ;
         }
         if ( sdt.IsDirty("NegDelUsuId") )
         {
            gxTv_SdtNegocioPJEstrutura_Negdelusuid_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusuid = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusuid ;
         }
         if ( sdt.IsDirty("NegDelUsuNome") )
         {
            gxTv_SdtNegocioPJEstrutura_Negdelusunome_N = (short)(sdt.gxTv_SdtNegocioPJEstrutura_Negdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusunome = sdt.gxTv_SdtNegocioPJEstrutura_Negdelusunome ;
         }
         if ( gxTv_SdtNegocioPJEstrutura_Fase != null )
         {
            GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase> newCollectionFase = sdt.gxTpr_Fase;
            GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase currItemFase;
            GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase newItemFase;
            short idx = 1;
            while ( idx <= newCollectionFase.Count )
            {
               newItemFase = ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)newCollectionFase.Item(idx));
               currItemFase = gxTv_SdtNegocioPJEstrutura_Fase.GetByKey(newItemFase.gxTpr_Ngfseq);
               if ( StringUtil.StrCmp(currItemFase.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemFase.UpdateDirties(newItemFase);
                  if ( StringUtil.StrCmp(newItemFase.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemFase.gxTpr_Mode = "DLT";
                  }
                  currItemFase.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtNegocioPJEstrutura_Fase.Add(newItemFase, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtNegocioPJEstrutura_Item != null )
         {
            GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item> newCollectionItem = sdt.gxTpr_Item;
            GeneXus.Programs.core.SdtNegocioPJEstrutura_Item currItemItem;
            GeneXus.Programs.core.SdtNegocioPJEstrutura_Item newItemItem;
            short idx = 1;
            while ( idx <= newCollectionItem.Count )
            {
               newItemItem = ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)newCollectionItem.Item(idx));
               currItemItem = gxTv_SdtNegocioPJEstrutura_Item.GetByKey(newItemItem.gxTpr_Ngpitem);
               if ( StringUtil.StrCmp(currItemItem.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemItem.UpdateDirties(newItemItem);
                  if ( StringUtil.StrCmp(newItemItem.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemItem.gxTpr_Mode = "DLT";
                  }
                  currItemItem.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtNegocioPJEstrutura_Item.Add(newItemItem, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "NegID" )]
      [  XmlElement( ElementName = "NegID"   )]
      public Guid gxTpr_Negid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNegocioPJEstrutura_Negid != value )
            {
               gxTv_SdtNegocioPJEstrutura_Mode = "INS";
               this.gxTv_SdtNegocioPJEstrutura_Negid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcodigo_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Neginsdata_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Neginshora_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcliid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negpjtid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negagcid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negagcnome_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negassunto_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negultfase_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negultiteid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negultitenome_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negultitem_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negdel_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negdeldata_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negdelhora_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z_SetNull( );
               this.gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z_SetNull( );
               if ( gxTv_SdtNegocioPJEstrutura_Fase != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase> collectionFase = gxTv_SdtNegocioPJEstrutura_Fase;
                  GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase currItemFase;
                  short idx = 1;
                  while ( idx <= collectionFase.Count )
                  {
                     currItemFase = ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase)collectionFase.Item(idx));
                     currItemFase.gxTpr_Mode = "INS";
                     currItemFase.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtNegocioPJEstrutura_Item != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item> collectionItem = gxTv_SdtNegocioPJEstrutura_Item;
                  GeneXus.Programs.core.SdtNegocioPJEstrutura_Item currItemItem;
                  short idx = 1;
                  while ( idx <= collectionItem.Count )
                  {
                     currItemItem = ((GeneXus.Programs.core.SdtNegocioPJEstrutura_Item)collectionItem.Item(idx));
                     currItemItem.gxTpr_Mode = "INS";
                     currItemItem.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtNegocioPJEstrutura_Negid = value;
            SetDirty("Negid");
         }

      }

      [  SoapElement( ElementName = "NegCodigo" )]
      [  XmlElement( ElementName = "NegCodigo"   )]
      public long gxTpr_Negcodigo
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcodigo = value;
            SetDirty("Negcodigo");
         }

      }

      [  SoapElement( ElementName = "NegInsData" )]
      [  XmlElement( ElementName = "NegInsData"  , IsNullable=true )]
      public string gxTpr_Neginsdata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Neginsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Neginsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Neginsdata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Neginsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Neginsdata
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsdata = value;
            SetDirty("Neginsdata");
         }

      }

      [  SoapElement( ElementName = "NegInsHora" )]
      [  XmlElement( ElementName = "NegInsHora"  , IsNullable=true )]
      public string gxTpr_Neginshora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Neginshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Neginshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Neginshora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Neginshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Neginshora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginshora = value;
            SetDirty("Neginshora");
         }

      }

      [  SoapElement( ElementName = "NegInsDataHora" )]
      [  XmlElement( ElementName = "NegInsDataHora"  , IsNullable=true )]
      public string gxTpr_Neginsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Neginsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Neginsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Neginsdatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Neginsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Neginsdatahora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsdatahora = value;
            SetDirty("Neginsdatahora");
         }

      }

      [  SoapElement( ElementName = "NegInsUsuID" )]
      [  XmlElement( ElementName = "NegInsUsuID"   )]
      public string gxTpr_Neginsusuid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsusuid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Neginsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusuid = value;
            SetDirty("Neginsusuid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsusuid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsusuid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Neginsusuid = "";
         SetDirty("Neginsusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Neginsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NegInsUsuNome" )]
      [  XmlElement( ElementName = "NegInsUsuNome"   )]
      public string gxTpr_Neginsusunome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsusunome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Neginsusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusunome = value;
            SetDirty("Neginsusunome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsusunome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsusunome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Neginsusunome = "";
         SetDirty("Neginsusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Neginsusunome_N==1) ;
      }

      [  SoapElement( ElementName = "NegCliID" )]
      [  XmlElement( ElementName = "NegCliID"   )]
      public Guid gxTpr_Negcliid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcliid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcliid = value;
            SetDirty("Negcliid");
         }

      }

      [  SoapElement( ElementName = "NegCliMatricula" )]
      [  XmlElement( ElementName = "NegCliMatricula"   )]
      public long gxTpr_Negclimatricula
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negclimatricula ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negclimatricula = value;
            SetDirty("Negclimatricula");
         }

      }

      [  SoapElement( ElementName = "NegCliNomeFamiliar" )]
      [  XmlElement( ElementName = "NegCliNomeFamiliar"   )]
      public string gxTpr_Negclinomefamiliar
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar = value;
            SetDirty("Negclinomefamiliar");
         }

      }

      [  SoapElement( ElementName = "NegCpjID" )]
      [  XmlElement( ElementName = "NegCpjID"   )]
      public Guid gxTpr_Negcpjid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjid = value;
            SetDirty("Negcpjid");
         }

      }

      [  SoapElement( ElementName = "NegCpjNomFan" )]
      [  XmlElement( ElementName = "NegCpjNomFan"   )]
      public string gxTpr_Negcpjnomfan
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjnomfan ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjnomfan = value;
            SetDirty("Negcpjnomfan");
         }

      }

      [  SoapElement( ElementName = "NegCpjRazSocial" )]
      [  XmlElement( ElementName = "NegCpjRazSocial"   )]
      public string gxTpr_Negcpjrazsocial
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial = value;
            SetDirty("Negcpjrazsocial");
         }

      }

      [  SoapElement( ElementName = "NegCpjMatricula" )]
      [  XmlElement( ElementName = "NegCpjMatricula"   )]
      public long gxTpr_Negcpjmatricula
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjmatricula ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjmatricula = value;
            SetDirty("Negcpjmatricula");
         }

      }

      [  SoapElement( ElementName = "NegPjtID" )]
      [  XmlElement( ElementName = "NegPjtID"   )]
      public int gxTpr_Negpjtid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpjtid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtid = value;
            SetDirty("Negpjtid");
         }

      }

      [  SoapElement( ElementName = "NegPjtSigla" )]
      [  XmlElement( ElementName = "NegPjtSigla"   )]
      public string gxTpr_Negpjtsigla
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpjtsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtsigla = value;
            SetDirty("Negpjtsigla");
         }

      }

      [  SoapElement( ElementName = "NegPjtNome" )]
      [  XmlElement( ElementName = "NegPjtNome"   )]
      public string gxTpr_Negpjtnome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpjtnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtnome = value;
            SetDirty("Negpjtnome");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndSeq" )]
      [  XmlElement( ElementName = "NegCpjEndSeq"   )]
      public short gxTpr_Negcpjendseq
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendseq ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendseq = value;
            SetDirty("Negcpjendseq");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndNome" )]
      [  XmlElement( ElementName = "NegCpjEndNome"   )]
      public string gxTpr_Negcpjendnome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendnome = value;
            SetDirty("Negcpjendnome");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndEndereco" )]
      [  XmlElement( ElementName = "NegCpjEndEndereco"   )]
      public string gxTpr_Negcpjendendereco
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendendereco ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendendereco = value;
            SetDirty("Negcpjendendereco");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndNumero" )]
      [  XmlElement( ElementName = "NegCpjEndNumero"   )]
      public string gxTpr_Negcpjendnumero
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendnumero ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendnumero = value;
            SetDirty("Negcpjendnumero");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndComplem" )]
      [  XmlElement( ElementName = "NegCpjEndComplem"   )]
      public string gxTpr_Negcpjendcomplem
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem = value;
            SetDirty("Negcpjendcomplem");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem = "";
         SetDirty("Negcpjendcomplem");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N==1) ;
      }

      [  SoapElement( ElementName = "NegCpjEndBairro" )]
      [  XmlElement( ElementName = "NegCpjEndBairro"   )]
      public string gxTpr_Negcpjendbairro
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendbairro ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendbairro = value;
            SetDirty("Negcpjendbairro");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndMunID" )]
      [  XmlElement( ElementName = "NegCpjEndMunID"   )]
      public int gxTpr_Negcpjendmunid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendmunid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendmunid = value;
            SetDirty("Negcpjendmunid");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndMunNome" )]
      [  XmlElement( ElementName = "NegCpjEndMunNome"   )]
      public string gxTpr_Negcpjendmunnome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome = value;
            SetDirty("Negcpjendmunnome");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndUFID" )]
      [  XmlElement( ElementName = "NegCpjEndUFID"   )]
      public short gxTpr_Negcpjendufid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendufid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufid = value;
            SetDirty("Negcpjendufid");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndUFSigla" )]
      [  XmlElement( ElementName = "NegCpjEndUFSigla"   )]
      public string gxTpr_Negcpjendufsigla
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla = value;
            SetDirty("Negcpjendufsigla");
         }

      }

      [  SoapElement( ElementName = "NegCpjEndUFNome" )]
      [  XmlElement( ElementName = "NegCpjEndUFNome"   )]
      public string gxTpr_Negcpjendufnome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendufnome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufnome = value;
            SetDirty("Negcpjendufnome");
         }

      }

      [  SoapElement( ElementName = "NegAgcID" )]
      [  XmlElement( ElementName = "NegAgcID"   )]
      public string gxTpr_Negagcid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negagcid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negagcid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcid = value;
            SetDirty("Negagcid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negagcid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negagcid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negagcid = "";
         SetDirty("Negagcid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negagcid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negagcid_N==1) ;
      }

      [  SoapElement( ElementName = "NegAgcNome" )]
      [  XmlElement( ElementName = "NegAgcNome"   )]
      public string gxTpr_Negagcnome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negagcnome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negagcnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcnome = value;
            SetDirty("Negagcnome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negagcnome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negagcnome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negagcnome = "";
         SetDirty("Negagcnome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negagcnome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negagcnome_N==1) ;
      }

      [  SoapElement( ElementName = "NegAssunto" )]
      [  XmlElement( ElementName = "NegAssunto"   )]
      public string gxTpr_Negassunto
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negassunto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negassunto = value;
            SetDirty("Negassunto");
         }

      }

      [  SoapElement( ElementName = "NegDescricao" )]
      [  XmlElement( ElementName = "NegDescricao"   )]
      public string gxTpr_Negdescricao
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdescricao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdescricao = value;
            SetDirty("Negdescricao");
         }

      }

      [  SoapElement( ElementName = "NegUltFase" )]
      [  XmlElement( ElementName = "NegUltFase"   )]
      public int gxTpr_Negultfase
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultfase ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultfase = value;
            SetDirty("Negultfase");
         }

      }

      [  SoapElement( ElementName = "NegUltNgfSeq" )]
      [  XmlElement( ElementName = "NegUltNgfSeq"   )]
      public int gxTpr_Negultngfseq
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultngfseq ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negultngfseq_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultngfseq = value;
            SetDirty("Negultngfseq");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultngfseq_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultngfseq_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negultngfseq = 0;
         SetDirty("Negultngfseq");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultngfseq_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negultngfseq_N==1) ;
      }

      [  SoapElement( ElementName = "NegUltIteID" )]
      [  XmlElement( ElementName = "NegUltIteID"   )]
      public Guid gxTpr_Negultiteid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultiteid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negultiteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteid = value;
            SetDirty("Negultiteid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultiteid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultiteid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negultiteid = Guid.Empty;
         SetDirty("Negultiteid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultiteid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negultiteid_N==1) ;
      }

      [  SoapElement( ElementName = "NegUltIteNome" )]
      [  XmlElement( ElementName = "NegUltIteNome"   )]
      public string gxTpr_Negultitenome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultitenome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negultitenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitenome = value;
            SetDirty("Negultitenome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultitenome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultitenome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negultitenome = "";
         SetDirty("Negultitenome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultitenome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negultitenome_N==1) ;
      }

      [  SoapElement( ElementName = "NegUltIteOrdem" )]
      [  XmlElement( ElementName = "NegUltIteOrdem"   )]
      public short gxTpr_Negultiteordem
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultiteordem ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negultiteordem_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteordem = value;
            SetDirty("Negultiteordem");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultiteordem_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultiteordem_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negultiteordem = 0;
         SetDirty("Negultiteordem");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultiteordem_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negultiteordem_N==1) ;
      }

      [  SoapElement( ElementName = "NegPgpTotal" )]
      [  XmlElement( ElementName = "NegPgpTotal"   )]
      public decimal gxTpr_Negpgptotal
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpgptotal ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negpgptotal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpgptotal = value;
            SetDirty("Negpgptotal");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negpgptotal_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negpgptotal_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negpgptotal = 0;
         SetDirty("Negpgptotal");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negpgptotal_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negpgptotal_N==1) ;
      }

      [  SoapElement( ElementName = "NegValorEstimado" )]
      [  XmlElement( ElementName = "NegValorEstimado"   )]
      public decimal gxTpr_Negvalorestimado
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negvalorestimado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negvalorestimado = value;
            SetDirty("Negvalorestimado");
         }

      }

      [  SoapElement( ElementName = "NegValorAtualizado" )]
      [  XmlElement( ElementName = "NegValorAtualizado"   )]
      public decimal gxTpr_Negvaloratualizado
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negvaloratualizado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negvaloratualizado = value;
            SetDirty("Negvaloratualizado");
         }

      }

      [  SoapElement( ElementName = "NegUltItem" )]
      [  XmlElement( ElementName = "NegUltItem"   )]
      public int gxTpr_Negultitem
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultitem ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negultitem_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitem = value;
            SetDirty("Negultitem");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultitem_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultitem_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negultitem = 0;
         SetDirty("Negultitem");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultitem_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negultitem_N==1) ;
      }

      [  SoapElement( ElementName = "NegDel" )]
      [  XmlElement( ElementName = "NegDel"   )]
      public bool gxTpr_Negdel
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdel = value;
            SetDirty("Negdel");
         }

      }

      [  SoapElement( ElementName = "NegDelDataHora" )]
      [  XmlElement( ElementName = "NegDelDataHora"  , IsNullable=true )]
      public string gxTpr_Negdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Negdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Negdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Negdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Negdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Negdeldatahora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdeldatahora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldatahora = value;
            SetDirty("Negdeldatahora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdeldatahora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Negdeldatahora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdeldatahora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "NegDelData" )]
      [  XmlElement( ElementName = "NegDelData"  , IsNullable=true )]
      public string gxTpr_Negdeldata_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Negdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Negdeldata).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Negdeldata = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Negdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Negdeldata
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdeldata ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldata = value;
            SetDirty("Negdeldata");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdeldata_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdeldata_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Negdeldata");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdeldata_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "NegDelHora" )]
      [  XmlElement( ElementName = "NegDelHora"  , IsNullable=true )]
      public string gxTpr_Negdelhora_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Negdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Negdelhora).value ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Negdelhora = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Negdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Negdelhora
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelhora ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelhora = value;
            SetDirty("Negdelhora");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelhora_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelhora_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Negdelhora");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelhora_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "NegDelUsuId" )]
      [  XmlElement( ElementName = "NegDelUsuId"   )]
      public string gxTpr_Negdelusuid
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelusuid ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusuid = value;
            SetDirty("Negdelusuid");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelusuid_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelusuid_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negdelusuid = "";
         SetDirty("Negdelusuid");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelusuid_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "NegDelUsuNome" )]
      [  XmlElement( ElementName = "NegDelUsuNome"   )]
      public string gxTpr_Negdelusunome
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelusunome ;
         }

         set {
            gxTv_SdtNegocioPJEstrutura_Negdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusunome = value;
            SetDirty("Negdelusunome");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelusunome_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelusunome_N = 1;
         gxTv_SdtNegocioPJEstrutura_Negdelusunome = "";
         SetDirty("Negdelusunome");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelusunome_IsNull( )
      {
         return (gxTv_SdtNegocioPJEstrutura_Negdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Fase" )]
      [  XmlArray( ElementName = "Fase"  )]
      [  XmlArrayItemAttribute( ElementName= "NegocioPJEstrutura.Fase"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase> gxTpr_Fase_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase == null )
            {
               gxTv_SdtNegocioPJEstrutura_Fase = new GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase>( context, "NegocioPJEstrutura.Fase", "agl_tresorygroup");
            }
            return gxTv_SdtNegocioPJEstrutura_Fase ;
         }

         set {
            if ( gxTv_SdtNegocioPJEstrutura_Fase == null )
            {
               gxTv_SdtNegocioPJEstrutura_Fase = new GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase>( context, "NegocioPJEstrutura.Fase", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase> gxTpr_Fase
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Fase == null )
            {
               gxTv_SdtNegocioPJEstrutura_Fase = new GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase>( context, "NegocioPJEstrutura.Fase", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            return gxTv_SdtNegocioPJEstrutura_Fase ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Fase = value;
            SetDirty("Fase");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Fase_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Fase = null;
         SetDirty("Fase");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Fase_IsNull( )
      {
         if ( gxTv_SdtNegocioPJEstrutura_Fase == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Item" )]
      [  XmlArray( ElementName = "Item"  )]
      [  XmlArrayItemAttribute( ElementName= "NegocioPJEstrutura.Item"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item> gxTpr_Item_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item == null )
            {
               gxTv_SdtNegocioPJEstrutura_Item = new GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item>( context, "NegocioPJEstrutura.Item", "agl_tresorygroup");
            }
            return gxTv_SdtNegocioPJEstrutura_Item ;
         }

         set {
            if ( gxTv_SdtNegocioPJEstrutura_Item == null )
            {
               gxTv_SdtNegocioPJEstrutura_Item = new GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item>( context, "NegocioPJEstrutura.Item", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item> gxTpr_Item
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Item == null )
            {
               gxTv_SdtNegocioPJEstrutura_Item = new GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item>( context, "NegocioPJEstrutura.Item", "agl_tresorygroup");
            }
            sdtIsNull = 0;
            return gxTv_SdtNegocioPJEstrutura_Item ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Item = value;
            SetDirty("Item");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Item_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Item = null;
         SetDirty("Item");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Item_IsNull( )
      {
         if ( gxTv_SdtNegocioPJEstrutura_Item == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Mode_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Initialized_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegID_Z" )]
      [  XmlElement( ElementName = "NegID_Z"   )]
      public Guid gxTpr_Negid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negid_Z = value;
            SetDirty("Negid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negid_Z = Guid.Empty;
         SetDirty("Negid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCodigo_Z" )]
      [  XmlElement( ElementName = "NegCodigo_Z"   )]
      public long gxTpr_Negcodigo_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcodigo_Z = value;
            SetDirty("Negcodigo_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcodigo_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcodigo_Z = 0;
         SetDirty("Negcodigo_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegInsData_Z" )]
      [  XmlElement( ElementName = "NegInsData_Z"  , IsNullable=true )]
      public string gxTpr_Neginsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Neginsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtNegocioPJEstrutura_Neginsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Neginsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Neginsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Neginsdata_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsdata_Z = value;
            SetDirty("Neginsdata_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsdata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Neginsdata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegInsHora_Z" )]
      [  XmlElement( ElementName = "NegInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Neginshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Neginshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Neginshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Neginshora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Neginshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Neginshora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginshora_Z = value;
            SetDirty("Neginshora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginshora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Neginshora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegInsDataHora_Z" )]
      [  XmlElement( ElementName = "NegInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Neginsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Neginsdatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z = value;
            SetDirty("Neginsdatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Neginsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegInsUsuID_Z" )]
      [  XmlElement( ElementName = "NegInsUsuID_Z"   )]
      public string gxTpr_Neginsusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z = value;
            SetDirty("Neginsusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z = "";
         SetDirty("Neginsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegInsUsuNome_Z" )]
      [  XmlElement( ElementName = "NegInsUsuNome_Z"   )]
      public string gxTpr_Neginsusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z = value;
            SetDirty("Neginsusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z = "";
         SetDirty("Neginsusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCliID_Z" )]
      [  XmlElement( ElementName = "NegCliID_Z"   )]
      public Guid gxTpr_Negcliid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcliid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcliid_Z = value;
            SetDirty("Negcliid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcliid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcliid_Z = Guid.Empty;
         SetDirty("Negcliid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcliid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCliMatricula_Z" )]
      [  XmlElement( ElementName = "NegCliMatricula_Z"   )]
      public long gxTpr_Negclimatricula_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z = value;
            SetDirty("Negclimatricula_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z = 0;
         SetDirty("Negclimatricula_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCliNomeFamiliar_Z" )]
      [  XmlElement( ElementName = "NegCliNomeFamiliar_Z"   )]
      public string gxTpr_Negclinomefamiliar_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z = value;
            SetDirty("Negclinomefamiliar_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z = "";
         SetDirty("Negclinomefamiliar_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjID_Z" )]
      [  XmlElement( ElementName = "NegCpjID_Z"   )]
      public Guid gxTpr_Negcpjid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjid_Z = value;
            SetDirty("Negcpjid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjid_Z = Guid.Empty;
         SetDirty("Negcpjid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjNomFan_Z" )]
      [  XmlElement( ElementName = "NegCpjNomFan_Z"   )]
      public string gxTpr_Negcpjnomfan_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z = value;
            SetDirty("Negcpjnomfan_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z = "";
         SetDirty("Negcpjnomfan_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjRazSocial_Z" )]
      [  XmlElement( ElementName = "NegCpjRazSocial_Z"   )]
      public string gxTpr_Negcpjrazsocial_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z = value;
            SetDirty("Negcpjrazsocial_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z = "";
         SetDirty("Negcpjrazsocial_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjMatricula_Z" )]
      [  XmlElement( ElementName = "NegCpjMatricula_Z"   )]
      public long gxTpr_Negcpjmatricula_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z = value;
            SetDirty("Negcpjmatricula_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z = 0;
         SetDirty("Negcpjmatricula_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegPjtID_Z" )]
      [  XmlElement( ElementName = "NegPjtID_Z"   )]
      public int gxTpr_Negpjtid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpjtid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtid_Z = value;
            SetDirty("Negpjtid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negpjtid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negpjtid_Z = 0;
         SetDirty("Negpjtid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negpjtid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegPjtSigla_Z" )]
      [  XmlElement( ElementName = "NegPjtSigla_Z"   )]
      public string gxTpr_Negpjtsigla_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z = value;
            SetDirty("Negpjtsigla_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z = "";
         SetDirty("Negpjtsigla_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegPjtNome_Z" )]
      [  XmlElement( ElementName = "NegPjtNome_Z"   )]
      public string gxTpr_Negpjtnome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z = value;
            SetDirty("Negpjtnome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z = "";
         SetDirty("Negpjtnome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndSeq_Z" )]
      [  XmlElement( ElementName = "NegCpjEndSeq_Z"   )]
      public short gxTpr_Negcpjendseq_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z = value;
            SetDirty("Negcpjendseq_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z = 0;
         SetDirty("Negcpjendseq_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndNome_Z" )]
      [  XmlElement( ElementName = "NegCpjEndNome_Z"   )]
      public string gxTpr_Negcpjendnome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z = value;
            SetDirty("Negcpjendnome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z = "";
         SetDirty("Negcpjendnome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndEndereco_Z" )]
      [  XmlElement( ElementName = "NegCpjEndEndereco_Z"   )]
      public string gxTpr_Negcpjendendereco_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z = value;
            SetDirty("Negcpjendendereco_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z = "";
         SetDirty("Negcpjendendereco_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndNumero_Z" )]
      [  XmlElement( ElementName = "NegCpjEndNumero_Z"   )]
      public string gxTpr_Negcpjendnumero_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z = value;
            SetDirty("Negcpjendnumero_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z = "";
         SetDirty("Negcpjendnumero_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndComplem_Z" )]
      [  XmlElement( ElementName = "NegCpjEndComplem_Z"   )]
      public string gxTpr_Negcpjendcomplem_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z = value;
            SetDirty("Negcpjendcomplem_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z = "";
         SetDirty("Negcpjendcomplem_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndBairro_Z" )]
      [  XmlElement( ElementName = "NegCpjEndBairro_Z"   )]
      public string gxTpr_Negcpjendbairro_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z = value;
            SetDirty("Negcpjendbairro_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z = "";
         SetDirty("Negcpjendbairro_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndMunID_Z" )]
      [  XmlElement( ElementName = "NegCpjEndMunID_Z"   )]
      public int gxTpr_Negcpjendmunid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z = value;
            SetDirty("Negcpjendmunid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z = 0;
         SetDirty("Negcpjendmunid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndMunNome_Z" )]
      [  XmlElement( ElementName = "NegCpjEndMunNome_Z"   )]
      public string gxTpr_Negcpjendmunnome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z = value;
            SetDirty("Negcpjendmunnome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z = "";
         SetDirty("Negcpjendmunnome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndUFID_Z" )]
      [  XmlElement( ElementName = "NegCpjEndUFID_Z"   )]
      public short gxTpr_Negcpjendufid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z = value;
            SetDirty("Negcpjendufid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z = 0;
         SetDirty("Negcpjendufid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndUFSigla_Z" )]
      [  XmlElement( ElementName = "NegCpjEndUFSigla_Z"   )]
      public string gxTpr_Negcpjendufsigla_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z = value;
            SetDirty("Negcpjendufsigla_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z = "";
         SetDirty("Negcpjendufsigla_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndUFNome_Z" )]
      [  XmlElement( ElementName = "NegCpjEndUFNome_Z"   )]
      public string gxTpr_Negcpjendufnome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z = value;
            SetDirty("Negcpjendufnome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z = "";
         SetDirty("Negcpjendufnome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegAgcID_Z" )]
      [  XmlElement( ElementName = "NegAgcID_Z"   )]
      public string gxTpr_Negagcid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negagcid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcid_Z = value;
            SetDirty("Negagcid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negagcid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negagcid_Z = "";
         SetDirty("Negagcid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negagcid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegAgcNome_Z" )]
      [  XmlElement( ElementName = "NegAgcNome_Z"   )]
      public string gxTpr_Negagcnome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negagcnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcnome_Z = value;
            SetDirty("Negagcnome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negagcnome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negagcnome_Z = "";
         SetDirty("Negagcnome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negagcnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegAssunto_Z" )]
      [  XmlElement( ElementName = "NegAssunto_Z"   )]
      public string gxTpr_Negassunto_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negassunto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negassunto_Z = value;
            SetDirty("Negassunto_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negassunto_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negassunto_Z = "";
         SetDirty("Negassunto_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negassunto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltFase_Z" )]
      [  XmlElement( ElementName = "NegUltFase_Z"   )]
      public int gxTpr_Negultfase_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultfase_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultfase_Z = value;
            SetDirty("Negultfase_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultfase_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultfase_Z = 0;
         SetDirty("Negultfase_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultfase_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltNgfSeq_Z" )]
      [  XmlElement( ElementName = "NegUltNgfSeq_Z"   )]
      public int gxTpr_Negultngfseq_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z = value;
            SetDirty("Negultngfseq_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z = 0;
         SetDirty("Negultngfseq_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltIteID_Z" )]
      [  XmlElement( ElementName = "NegUltIteID_Z"   )]
      public Guid gxTpr_Negultiteid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultiteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteid_Z = value;
            SetDirty("Negultiteid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultiteid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultiteid_Z = Guid.Empty;
         SetDirty("Negultiteid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultiteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltIteNome_Z" )]
      [  XmlElement( ElementName = "NegUltIteNome_Z"   )]
      public string gxTpr_Negultitenome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultitenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitenome_Z = value;
            SetDirty("Negultitenome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultitenome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultitenome_Z = "";
         SetDirty("Negultitenome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultitenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltIteOrdem_Z" )]
      [  XmlElement( ElementName = "NegUltIteOrdem_Z"   )]
      public short gxTpr_Negultiteordem_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z = value;
            SetDirty("Negultiteordem_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z = 0;
         SetDirty("Negultiteordem_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegPgpTotal_Z" )]
      [  XmlElement( ElementName = "NegPgpTotal_Z"   )]
      public decimal gxTpr_Negpgptotal_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z = value;
            SetDirty("Negpgptotal_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z = 0;
         SetDirty("Negpgptotal_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegValorEstimado_Z" )]
      [  XmlElement( ElementName = "NegValorEstimado_Z"   )]
      public decimal gxTpr_Negvalorestimado_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z = value;
            SetDirty("Negvalorestimado_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z = 0;
         SetDirty("Negvalorestimado_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegValorAtualizado_Z" )]
      [  XmlElement( ElementName = "NegValorAtualizado_Z"   )]
      public decimal gxTpr_Negvaloratualizado_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z = value;
            SetDirty("Negvaloratualizado_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z = 0;
         SetDirty("Negvaloratualizado_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltItem_Z" )]
      [  XmlElement( ElementName = "NegUltItem_Z"   )]
      public int gxTpr_Negultitem_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultitem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitem_Z = value;
            SetDirty("Negultitem_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultitem_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultitem_Z = 0;
         SetDirty("Negultitem_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultitem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDel_Z" )]
      [  XmlElement( ElementName = "NegDel_Z"   )]
      public bool gxTpr_Negdel_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdel_Z = value;
            SetDirty("Negdel_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdel_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdel_Z = false;
         SetDirty("Negdel_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelDataHora_Z" )]
      [  XmlElement( ElementName = "NegDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Negdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Negdeldatahora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z = value;
            SetDirty("Negdeldatahora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Negdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelData_Z" )]
      [  XmlElement( ElementName = "NegDelData_Z"  , IsNullable=true )]
      public string gxTpr_Negdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Negdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Negdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Negdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Negdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Negdeldata_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldata_Z = value;
            SetDirty("Negdeldata_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdeldata_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Negdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelHora_Z" )]
      [  XmlElement( ElementName = "NegDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Negdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtNegocioPJEstrutura_Negdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNegocioPJEstrutura_Negdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNegocioPJEstrutura_Negdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtNegocioPJEstrutura_Negdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Negdelhora_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelhora_Z = value;
            SetDirty("Negdelhora_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelhora_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Negdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelUsuId_Z" )]
      [  XmlElement( ElementName = "NegDelUsuId_Z"   )]
      public string gxTpr_Negdelusuid_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z = value;
            SetDirty("Negdelusuid_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z = "";
         SetDirty("Negdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelUsuNome_Z" )]
      [  XmlElement( ElementName = "NegDelUsuNome_Z"   )]
      public string gxTpr_Negdelusunome_Z
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z = value;
            SetDirty("Negdelusunome_Z");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z = "";
         SetDirty("Negdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegInsUsuID_N" )]
      [  XmlElement( ElementName = "NegInsUsuID_N"   )]
      public short gxTpr_Neginsusuid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusuid_N = value;
            SetDirty("Neginsusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsusuid_N = 0;
         SetDirty("Neginsusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegInsUsuNome_N" )]
      [  XmlElement( ElementName = "NegInsUsuNome_N"   )]
      public short gxTpr_Neginsusunome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Neginsusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Neginsusunome_N = value;
            SetDirty("Neginsusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Neginsusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Neginsusunome_N = 0;
         SetDirty("Neginsusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Neginsusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegCpjEndComplem_N" )]
      [  XmlElement( ElementName = "NegCpjEndComplem_N"   )]
      public short gxTpr_Negcpjendcomplem_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N = value;
            SetDirty("Negcpjendcomplem_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N = 0;
         SetDirty("Negcpjendcomplem_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegAgcID_N" )]
      [  XmlElement( ElementName = "NegAgcID_N"   )]
      public short gxTpr_Negagcid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negagcid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcid_N = value;
            SetDirty("Negagcid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negagcid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negagcid_N = 0;
         SetDirty("Negagcid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negagcid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegAgcNome_N" )]
      [  XmlElement( ElementName = "NegAgcNome_N"   )]
      public short gxTpr_Negagcnome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negagcnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negagcnome_N = value;
            SetDirty("Negagcnome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negagcnome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negagcnome_N = 0;
         SetDirty("Negagcnome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negagcnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltNgfSeq_N" )]
      [  XmlElement( ElementName = "NegUltNgfSeq_N"   )]
      public short gxTpr_Negultngfseq_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultngfseq_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultngfseq_N = value;
            SetDirty("Negultngfseq_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultngfseq_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultngfseq_N = 0;
         SetDirty("Negultngfseq_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultngfseq_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltIteID_N" )]
      [  XmlElement( ElementName = "NegUltIteID_N"   )]
      public short gxTpr_Negultiteid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultiteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteid_N = value;
            SetDirty("Negultiteid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultiteid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultiteid_N = 0;
         SetDirty("Negultiteid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultiteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltIteNome_N" )]
      [  XmlElement( ElementName = "NegUltIteNome_N"   )]
      public short gxTpr_Negultitenome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultitenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitenome_N = value;
            SetDirty("Negultitenome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultitenome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultitenome_N = 0;
         SetDirty("Negultitenome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultitenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltIteOrdem_N" )]
      [  XmlElement( ElementName = "NegUltIteOrdem_N"   )]
      public short gxTpr_Negultiteordem_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultiteordem_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultiteordem_N = value;
            SetDirty("Negultiteordem_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultiteordem_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultiteordem_N = 0;
         SetDirty("Negultiteordem_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultiteordem_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegPgpTotal_N" )]
      [  XmlElement( ElementName = "NegPgpTotal_N"   )]
      public short gxTpr_Negpgptotal_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negpgptotal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negpgptotal_N = value;
            SetDirty("Negpgptotal_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negpgptotal_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negpgptotal_N = 0;
         SetDirty("Negpgptotal_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negpgptotal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegUltItem_N" )]
      [  XmlElement( ElementName = "NegUltItem_N"   )]
      public short gxTpr_Negultitem_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negultitem_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negultitem_N = value;
            SetDirty("Negultitem_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negultitem_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negultitem_N = 0;
         SetDirty("Negultitem_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negultitem_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelDataHora_N" )]
      [  XmlElement( ElementName = "NegDelDataHora_N"   )]
      public short gxTpr_Negdeldatahora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N = value;
            SetDirty("Negdeldatahora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N = 0;
         SetDirty("Negdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelData_N" )]
      [  XmlElement( ElementName = "NegDelData_N"   )]
      public short gxTpr_Negdeldata_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdeldata_N = value;
            SetDirty("Negdeldata_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdeldata_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdeldata_N = 0;
         SetDirty("Negdeldata_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelHora_N" )]
      [  XmlElement( ElementName = "NegDelHora_N"   )]
      public short gxTpr_Negdelhora_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelhora_N = value;
            SetDirty("Negdelhora_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelhora_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelhora_N = 0;
         SetDirty("Negdelhora_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelUsuId_N" )]
      [  XmlElement( ElementName = "NegDelUsuId_N"   )]
      public short gxTpr_Negdelusuid_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusuid_N = value;
            SetDirty("Negdelusuid_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelusuid_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelusuid_N = 0;
         SetDirty("Negdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NegDelUsuNome_N" )]
      [  XmlElement( ElementName = "NegDelUsuNome_N"   )]
      public short gxTpr_Negdelusunome_N
      {
         get {
            return gxTv_SdtNegocioPJEstrutura_Negdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNegocioPJEstrutura_Negdelusunome_N = value;
            SetDirty("Negdelusunome_N");
         }

      }

      public void gxTv_SdtNegocioPJEstrutura_Negdelusunome_N_SetNull( )
      {
         gxTv_SdtNegocioPJEstrutura_Negdelusunome_N = 0;
         SetDirty("Negdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtNegocioPJEstrutura_Negdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtNegocioPJEstrutura_Negid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtNegocioPJEstrutura_Neginsdata = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Neginshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Neginsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Neginsusuid = "";
         gxTv_SdtNegocioPJEstrutura_Neginsusunome = "";
         gxTv_SdtNegocioPJEstrutura_Negcliid = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjid = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Negcpjnomfan = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial = "";
         gxTv_SdtNegocioPJEstrutura_Negpjtsigla = "";
         gxTv_SdtNegocioPJEstrutura_Negpjtnome = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendnome = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendendereco = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendnumero = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendbairro = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendufnome = "";
         gxTv_SdtNegocioPJEstrutura_Negagcid = "";
         gxTv_SdtNegocioPJEstrutura_Negagcnome = "";
         gxTv_SdtNegocioPJEstrutura_Negassunto = "";
         gxTv_SdtNegocioPJEstrutura_Negdescricao = "";
         gxTv_SdtNegocioPJEstrutura_Negultiteid = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Negultitenome = "";
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Negdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Negdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Negdelusuid = "";
         gxTv_SdtNegocioPJEstrutura_Negdelusunome = "";
         gxTv_SdtNegocioPJEstrutura_Mode = "";
         gxTv_SdtNegocioPJEstrutura_Negid_Z = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Neginsdata_Z = DateTime.MinValue;
         gxTv_SdtNegocioPJEstrutura_Neginshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcliid_Z = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjid_Z = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negagcid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negagcnome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negassunto_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negultiteid_Z = Guid.Empty;
         gxTv_SdtNegocioPJEstrutura_Negultitenome_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Negdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Negdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z = "";
         gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.negociopjestrutura", "GeneXus.Programs.core.negociopjestrutura_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtNegocioPJEstrutura_Negcpjendseq ;
      private short gxTv_SdtNegocioPJEstrutura_Negcpjendufid ;
      private short gxTv_SdtNegocioPJEstrutura_Negultiteordem ;
      private short gxTv_SdtNegocioPJEstrutura_Initialized ;
      private short gxTv_SdtNegocioPJEstrutura_Negcpjendseq_Z ;
      private short gxTv_SdtNegocioPJEstrutura_Negcpjendufid_Z ;
      private short gxTv_SdtNegocioPJEstrutura_Negultiteordem_Z ;
      private short gxTv_SdtNegocioPJEstrutura_Neginsusuid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Neginsusunome_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negagcid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negagcnome_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negultngfseq_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negultiteid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negultitenome_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negultiteordem_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negpgptotal_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negultitem_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negdeldatahora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negdeldata_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negdelhora_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negdelusuid_N ;
      private short gxTv_SdtNegocioPJEstrutura_Negdelusunome_N ;
      private int gxTv_SdtNegocioPJEstrutura_Negpjtid ;
      private int gxTv_SdtNegocioPJEstrutura_Negcpjendmunid ;
      private int gxTv_SdtNegocioPJEstrutura_Negultfase ;
      private int gxTv_SdtNegocioPJEstrutura_Negultngfseq ;
      private int gxTv_SdtNegocioPJEstrutura_Negultitem ;
      private int gxTv_SdtNegocioPJEstrutura_Negpjtid_Z ;
      private int gxTv_SdtNegocioPJEstrutura_Negcpjendmunid_Z ;
      private int gxTv_SdtNegocioPJEstrutura_Negultfase_Z ;
      private int gxTv_SdtNegocioPJEstrutura_Negultngfseq_Z ;
      private int gxTv_SdtNegocioPJEstrutura_Negultitem_Z ;
      private long gxTv_SdtNegocioPJEstrutura_Negcodigo ;
      private long gxTv_SdtNegocioPJEstrutura_Negclimatricula ;
      private long gxTv_SdtNegocioPJEstrutura_Negcpjmatricula ;
      private long gxTv_SdtNegocioPJEstrutura_Negcodigo_Z ;
      private long gxTv_SdtNegocioPJEstrutura_Negclimatricula_Z ;
      private long gxTv_SdtNegocioPJEstrutura_Negcpjmatricula_Z ;
      private decimal gxTv_SdtNegocioPJEstrutura_Negpgptotal ;
      private decimal gxTv_SdtNegocioPJEstrutura_Negvalorestimado ;
      private decimal gxTv_SdtNegocioPJEstrutura_Negvaloratualizado ;
      private decimal gxTv_SdtNegocioPJEstrutura_Negpgptotal_Z ;
      private decimal gxTv_SdtNegocioPJEstrutura_Negvalorestimado_Z ;
      private decimal gxTv_SdtNegocioPJEstrutura_Negvaloratualizado_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Neginsusuid ;
      private string gxTv_SdtNegocioPJEstrutura_Negagcid ;
      private string gxTv_SdtNegocioPJEstrutura_Negdelusuid ;
      private string gxTv_SdtNegocioPJEstrutura_Mode ;
      private string gxTv_SdtNegocioPJEstrutura_Neginsusuid_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negagcid_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Neginshora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Neginsdatahora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Negdeldatahora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Negdeldata ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Negdelhora ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Neginshora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Neginsdatahora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Negdeldatahora_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Negdeldata_Z ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Negdelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Neginsdata ;
      private DateTime gxTv_SdtNegocioPJEstrutura_Neginsdata_Z ;
      private bool gxTv_SdtNegocioPJEstrutura_Negdel ;
      private bool gxTv_SdtNegocioPJEstrutura_Negdel_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negdescricao ;
      private string gxTv_SdtNegocioPJEstrutura_Neginsusunome ;
      private string gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjnomfan ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial ;
      private string gxTv_SdtNegocioPJEstrutura_Negpjtsigla ;
      private string gxTv_SdtNegocioPJEstrutura_Negpjtnome ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendnome ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendendereco ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendnumero ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendbairro ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendufnome ;
      private string gxTv_SdtNegocioPJEstrutura_Negagcnome ;
      private string gxTv_SdtNegocioPJEstrutura_Negassunto ;
      private string gxTv_SdtNegocioPJEstrutura_Negultitenome ;
      private string gxTv_SdtNegocioPJEstrutura_Negdelusunome ;
      private string gxTv_SdtNegocioPJEstrutura_Neginsusunome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negclinomefamiliar_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjnomfan_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjrazsocial_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negpjtsigla_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negpjtnome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendnome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendendereco_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendnumero_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendcomplem_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendbairro_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendmunnome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendufsigla_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negcpjendufnome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negagcnome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negassunto_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negultitenome_Z ;
      private string gxTv_SdtNegocioPJEstrutura_Negdelusunome_Z ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negid ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negcliid ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negcpjid ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negultiteid ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negid_Z ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negcliid_Z ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negcpjid_Z ;
      private Guid gxTv_SdtNegocioPJEstrutura_Negultiteid_Z ;
      private GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase> gxTv_SdtNegocioPJEstrutura_Fase=null ;
      private GXBCLevelCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item> gxTv_SdtNegocioPJEstrutura_Item=null ;
   }

   [DataContract(Name = @"core\NegocioPJEstrutura", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJEstrutura_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJEstrutura>
   {
      public SdtNegocioPJEstrutura_RESTInterface( ) : base()
      {
      }

      public SdtNegocioPJEstrutura_RESTInterface( GeneXus.Programs.core.SdtNegocioPJEstrutura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NegID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Negid
      {
         get {
            return sdt.gxTpr_Negid ;
         }

         set {
            sdt.gxTpr_Negid = value;
         }

      }

      [DataMember( Name = "NegCodigo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Negcodigo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negcodigo), 12, 0)) ;
         }

         set {
            sdt.gxTpr_Negcodigo = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegInsData" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Neginsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Neginsdata) ;
         }

         set {
            sdt.gxTpr_Neginsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "NegInsHora" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Neginshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Neginshora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Neginshora = GXt_dtime1;
         }

      }

      [DataMember( Name = "NegInsDataHora" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Neginsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Neginsdatahora) ;
         }

         set {
            sdt.gxTpr_Neginsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NegInsUsuID" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Neginsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Neginsusuid) ;
         }

         set {
            sdt.gxTpr_Neginsusuid = value;
         }

      }

      [DataMember( Name = "NegInsUsuNome" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Neginsusunome
      {
         get {
            return sdt.gxTpr_Neginsusunome ;
         }

         set {
            sdt.gxTpr_Neginsusunome = value;
         }

      }

      [DataMember( Name = "NegCliID" , Order = 7 )]
      [GxSeudo()]
      public Guid gxTpr_Negcliid
      {
         get {
            return sdt.gxTpr_Negcliid ;
         }

         set {
            sdt.gxTpr_Negcliid = value;
         }

      }

      [DataMember( Name = "NegCliMatricula" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Negclimatricula
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negclimatricula), 12, 0)) ;
         }

         set {
            sdt.gxTpr_Negclimatricula = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegCliNomeFamiliar" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Negclinomefamiliar
      {
         get {
            return sdt.gxTpr_Negclinomefamiliar ;
         }

         set {
            sdt.gxTpr_Negclinomefamiliar = value;
         }

      }

      [DataMember( Name = "NegCpjID" , Order = 10 )]
      [GxSeudo()]
      public Guid gxTpr_Negcpjid
      {
         get {
            return sdt.gxTpr_Negcpjid ;
         }

         set {
            sdt.gxTpr_Negcpjid = value;
         }

      }

      [DataMember( Name = "NegCpjNomFan" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Negcpjnomfan
      {
         get {
            return sdt.gxTpr_Negcpjnomfan ;
         }

         set {
            sdt.gxTpr_Negcpjnomfan = value;
         }

      }

      [DataMember( Name = "NegCpjRazSocial" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Negcpjrazsocial
      {
         get {
            return sdt.gxTpr_Negcpjrazsocial ;
         }

         set {
            sdt.gxTpr_Negcpjrazsocial = value;
         }

      }

      [DataMember( Name = "NegCpjMatricula" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Negcpjmatricula
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negcpjmatricula), 12, 0)) ;
         }

         set {
            sdt.gxTpr_Negcpjmatricula = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegPjtID" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Negpjtid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negpjtid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Negpjtid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegPjtSigla" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Negpjtsigla
      {
         get {
            return sdt.gxTpr_Negpjtsigla ;
         }

         set {
            sdt.gxTpr_Negpjtsigla = value;
         }

      }

      [DataMember( Name = "NegPjtNome" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Negpjtnome
      {
         get {
            return sdt.gxTpr_Negpjtnome ;
         }

         set {
            sdt.gxTpr_Negpjtnome = value;
         }

      }

      [DataMember( Name = "NegCpjEndSeq" , Order = 17 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Negcpjendseq
      {
         get {
            return sdt.gxTpr_Negcpjendseq ;
         }

         set {
            sdt.gxTpr_Negcpjendseq = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NegCpjEndNome" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendnome
      {
         get {
            return sdt.gxTpr_Negcpjendnome ;
         }

         set {
            sdt.gxTpr_Negcpjendnome = value;
         }

      }

      [DataMember( Name = "NegCpjEndEndereco" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendendereco
      {
         get {
            return sdt.gxTpr_Negcpjendendereco ;
         }

         set {
            sdt.gxTpr_Negcpjendendereco = value;
         }

      }

      [DataMember( Name = "NegCpjEndNumero" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendnumero
      {
         get {
            return sdt.gxTpr_Negcpjendnumero ;
         }

         set {
            sdt.gxTpr_Negcpjendnumero = value;
         }

      }

      [DataMember( Name = "NegCpjEndComplem" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendcomplem
      {
         get {
            return sdt.gxTpr_Negcpjendcomplem ;
         }

         set {
            sdt.gxTpr_Negcpjendcomplem = value;
         }

      }

      [DataMember( Name = "NegCpjEndBairro" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendbairro
      {
         get {
            return sdt.gxTpr_Negcpjendbairro ;
         }

         set {
            sdt.gxTpr_Negcpjendbairro = value;
         }

      }

      [DataMember( Name = "NegCpjEndMunID" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendmunid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negcpjendmunid), 7, 0)) ;
         }

         set {
            sdt.gxTpr_Negcpjendmunid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegCpjEndMunNome" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendmunnome
      {
         get {
            return sdt.gxTpr_Negcpjendmunnome ;
         }

         set {
            sdt.gxTpr_Negcpjendmunnome = value;
         }

      }

      [DataMember( Name = "NegCpjEndUFID" , Order = 25 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Negcpjendufid
      {
         get {
            return sdt.gxTpr_Negcpjendufid ;
         }

         set {
            sdt.gxTpr_Negcpjendufid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NegCpjEndUFSigla" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendufsigla
      {
         get {
            return sdt.gxTpr_Negcpjendufsigla ;
         }

         set {
            sdt.gxTpr_Negcpjendufsigla = value;
         }

      }

      [DataMember( Name = "NegCpjEndUFNome" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Negcpjendufnome
      {
         get {
            return sdt.gxTpr_Negcpjendufnome ;
         }

         set {
            sdt.gxTpr_Negcpjendufnome = value;
         }

      }

      [DataMember( Name = "NegAgcID" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Negagcid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Negagcid) ;
         }

         set {
            sdt.gxTpr_Negagcid = value;
         }

      }

      [DataMember( Name = "NegAgcNome" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Negagcnome
      {
         get {
            return sdt.gxTpr_Negagcnome ;
         }

         set {
            sdt.gxTpr_Negagcnome = value;
         }

      }

      [DataMember( Name = "NegAssunto" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Negassunto
      {
         get {
            return sdt.gxTpr_Negassunto ;
         }

         set {
            sdt.gxTpr_Negassunto = value;
         }

      }

      [DataMember( Name = "NegDescricao" , Order = 31 )]
      public string gxTpr_Negdescricao
      {
         get {
            return sdt.gxTpr_Negdescricao ;
         }

         set {
            sdt.gxTpr_Negdescricao = value;
         }

      }

      [DataMember( Name = "NegUltFase" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Negultfase
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negultfase), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Negultfase = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegUltNgfSeq" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Negultngfseq
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negultngfseq), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Negultngfseq = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegUltIteID" , Order = 34 )]
      [GxSeudo()]
      public Guid gxTpr_Negultiteid
      {
         get {
            return sdt.gxTpr_Negultiteid ;
         }

         set {
            sdt.gxTpr_Negultiteid = value;
         }

      }

      [DataMember( Name = "NegUltIteNome" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Negultitenome
      {
         get {
            return sdt.gxTpr_Negultitenome ;
         }

         set {
            sdt.gxTpr_Negultitenome = value;
         }

      }

      [DataMember( Name = "NegUltIteOrdem" , Order = 36 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Negultiteordem
      {
         get {
            return sdt.gxTpr_Negultiteordem ;
         }

         set {
            sdt.gxTpr_Negultiteordem = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NegPgpTotal" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Negpgptotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Negpgptotal, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Negpgptotal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NegValorEstimado" , Order = 38 )]
      [GxSeudo()]
      public string gxTpr_Negvalorestimado
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Negvalorestimado, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Negvalorestimado = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NegValorAtualizado" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Negvaloratualizado
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Negvaloratualizado, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Negvaloratualizado = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NegUltItem" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Negultitem
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Negultitem), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Negultitem = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NegDel" , Order = 41 )]
      [GxSeudo()]
      public bool gxTpr_Negdel
      {
         get {
            return sdt.gxTpr_Negdel ;
         }

         set {
            sdt.gxTpr_Negdel = value;
         }

      }

      [DataMember( Name = "NegDelDataHora" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Negdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Negdeldatahora) ;
         }

         set {
            sdt.gxTpr_Negdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NegDelData" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Negdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Negdeldata) ;
         }

         set {
            sdt.gxTpr_Negdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "NegDelHora" , Order = 44 )]
      [GxSeudo()]
      public string gxTpr_Negdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Negdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Negdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "NegDelUsuId" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Negdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Negdelusuid) ;
         }

         set {
            sdt.gxTpr_Negdelusuid = value;
         }

      }

      [DataMember( Name = "NegDelUsuNome" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Negdelusunome
      {
         get {
            return sdt.gxTpr_Negdelusunome ;
         }

         set {
            sdt.gxTpr_Negdelusunome = value;
         }

      }

      [DataMember( Name = "Fase" , Order = 47 )]
      public GxGenericCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase_RESTInterface> gxTpr_Fase
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Fase_RESTInterface>(sdt.gxTpr_Fase) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Fase);
         }

      }

      [DataMember( Name = "Item" , Order = 48 )]
      public GxGenericCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item_RESTInterface> gxTpr_Item
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.core.SdtNegocioPJEstrutura_Item_RESTInterface>(sdt.gxTpr_Item) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Item);
         }

      }

      public GeneXus.Programs.core.SdtNegocioPJEstrutura sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJEstrutura)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.core.SdtNegocioPJEstrutura() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 49 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
      private DateTime GXt_dtime1 ;
   }

   [DataContract(Name = @"core\NegocioPJEstrutura", Namespace = "agl_tresorygroup")]
   public class SdtNegocioPJEstrutura_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtNegocioPJEstrutura>
   {
      public SdtNegocioPJEstrutura_RESTLInterface( ) : base()
      {
      }

      public SdtNegocioPJEstrutura_RESTLInterface( GeneXus.Programs.core.SdtNegocioPJEstrutura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NegAssunto" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Negassunto
      {
         get {
            return sdt.gxTpr_Negassunto ;
         }

         set {
            sdt.gxTpr_Negassunto = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.core.SdtNegocioPJEstrutura sdt
      {
         get {
            return (GeneXus.Programs.core.SdtNegocioPJEstrutura)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.core.SdtNegocioPJEstrutura() ;
         }
      }

   }

}
