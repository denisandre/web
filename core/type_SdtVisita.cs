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
   [XmlRoot(ElementName = "Visita" )]
   [XmlType(TypeName =  "Visita" , Namespace = "agl_tresorygroup" )]
   [Serializable]
   public class SdtVisita : GxSilentTrnSdt
   {
      public SdtVisita( )
      {
      }

      public SdtVisita( IGxContext context )
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

      public void Load( Guid AV398VisID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV398VisID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"VisID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "core\\Visita");
         metadata.Set("BT", "tb_visita");
         metadata.Set("PK", "[ \"VisID\" ]");
         metadata.Set("PKAssigned", "[ \"VisID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NegID\" ],\"FKMap\":[ \"VisNegID-NegID\" ] },{ \"FK\":[ \"NegID\",\"NgfSeq\" ],\"FKMap\":[ \"VisNegID-NegID\",\"VisNgfSeq-NgfSeq\" ] },{ \"FK\":[ \"VisID\" ],\"FKMap\":[ \"VisPaiID-VisID\" ] },{ \"FK\":[ \"VitID\" ],\"FKMap\":[ \"VisTipoID-VitID\" ] } ]");
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
         state.Add("gxTpr_Visid_Z");
         state.Add("gxTpr_Vispaiid_Z");
         state.Add("gxTpr_Vispaidata_Z_Nullable");
         state.Add("gxTpr_Vispaihora_Z_Nullable");
         state.Add("gxTpr_Vispaidatahora_Z_Nullable");
         state.Add("gxTpr_Vispaiassunto_Z");
         state.Add("gxTpr_Visinsdata_Z_Nullable");
         state.Add("gxTpr_Visinshora_Z_Nullable");
         state.Add("gxTpr_Visinsdatahora_Z_Nullable");
         state.Add("gxTpr_Visinsusuid_Z");
         state.Add("gxTpr_Visinsusunome_Z");
         state.Add("gxTpr_Visupddata_Z_Nullable");
         state.Add("gxTpr_Visupdhora_Z_Nullable");
         state.Add("gxTpr_Visupddatahora_Z_Nullable");
         state.Add("gxTpr_Visupdusuid_Z");
         state.Add("gxTpr_Visupdusunome_Z");
         state.Add("gxTpr_Visdata_Z_Nullable");
         state.Add("gxTpr_Vishora_Z_Nullable");
         state.Add("gxTpr_Visdatahora_Z_Nullable");
         state.Add("gxTpr_Visdatafim_Z_Nullable");
         state.Add("gxTpr_Vishorafim_Z_Nullable");
         state.Add("gxTpr_Visdatahorafim_Z_Nullable");
         state.Add("gxTpr_Vistipoid_Z");
         state.Add("gxTpr_Vistiposigla_Z");
         state.Add("gxTpr_Vistiponome_Z");
         state.Add("gxTpr_Visnegid_Z");
         state.Add("gxTpr_Visnegcodigo_Z");
         state.Add("gxTpr_Visnegassunto_Z");
         state.Add("gxTpr_Visnegvalor_Z");
         state.Add("gxTpr_Visnegcliid_Z");
         state.Add("gxTpr_Visnegclinomefamiliar_Z");
         state.Add("gxTpr_Visnegcpjid_Z");
         state.Add("gxTpr_Visnegcpjnomfan_Z");
         state.Add("gxTpr_Visnegcpjrazsocial_Z");
         state.Add("gxTpr_Visngfseq_Z");
         state.Add("gxTpr_Visngfiteid_Z");
         state.Add("gxTpr_Visngfitenome_Z");
         state.Add("gxTpr_Visassunto_Z");
         state.Add("gxTpr_Vislink_Z");
         state.Add("gxTpr_Vissituacao_Z");
         state.Add("gxTpr_Visdel_Z");
         state.Add("gxTpr_Visdeldatahora_Z_Nullable");
         state.Add("gxTpr_Visdeldata_Z_Nullable");
         state.Add("gxTpr_Visdelhora_Z_Nullable");
         state.Add("gxTpr_Visdelusuid_Z");
         state.Add("gxTpr_Visdelusunome_Z");
         state.Add("gxTpr_Vispaiid_N");
         state.Add("gxTpr_Visinsusuid_N");
         state.Add("gxTpr_Visinsusunome_N");
         state.Add("gxTpr_Visupddata_N");
         state.Add("gxTpr_Visupdhora_N");
         state.Add("gxTpr_Visupddatahora_N");
         state.Add("gxTpr_Visupdusuid_N");
         state.Add("gxTpr_Visupdusunome_N");
         state.Add("gxTpr_Visdatafim_N");
         state.Add("gxTpr_Vishorafim_N");
         state.Add("gxTpr_Visdatahorafim_N");
         state.Add("gxTpr_Visnegid_N");
         state.Add("gxTpr_Visngfseq_N");
         state.Add("gxTpr_Visdescricao_N");
         state.Add("gxTpr_Vislink_N");
         state.Add("gxTpr_Visdeldatahora_N");
         state.Add("gxTpr_Visdeldata_N");
         state.Add("gxTpr_Visdelhora_N");
         state.Add("gxTpr_Visdelusuid_N");
         state.Add("gxTpr_Visdelusunome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.core.SdtVisita sdt;
         sdt = (GeneXus.Programs.core.SdtVisita)(source);
         gxTv_SdtVisita_Visid = sdt.gxTv_SdtVisita_Visid ;
         gxTv_SdtVisita_Vispaiid = sdt.gxTv_SdtVisita_Vispaiid ;
         gxTv_SdtVisita_Vispaidata = sdt.gxTv_SdtVisita_Vispaidata ;
         gxTv_SdtVisita_Vispaihora = sdt.gxTv_SdtVisita_Vispaihora ;
         gxTv_SdtVisita_Vispaidatahora = sdt.gxTv_SdtVisita_Vispaidatahora ;
         gxTv_SdtVisita_Vispaiassunto = sdt.gxTv_SdtVisita_Vispaiassunto ;
         gxTv_SdtVisita_Visinsdata = sdt.gxTv_SdtVisita_Visinsdata ;
         gxTv_SdtVisita_Visinshora = sdt.gxTv_SdtVisita_Visinshora ;
         gxTv_SdtVisita_Visinsdatahora = sdt.gxTv_SdtVisita_Visinsdatahora ;
         gxTv_SdtVisita_Visinsusuid = sdt.gxTv_SdtVisita_Visinsusuid ;
         gxTv_SdtVisita_Visinsusunome = sdt.gxTv_SdtVisita_Visinsusunome ;
         gxTv_SdtVisita_Visupddata = sdt.gxTv_SdtVisita_Visupddata ;
         gxTv_SdtVisita_Visupdhora = sdt.gxTv_SdtVisita_Visupdhora ;
         gxTv_SdtVisita_Visupddatahora = sdt.gxTv_SdtVisita_Visupddatahora ;
         gxTv_SdtVisita_Visupdusuid = sdt.gxTv_SdtVisita_Visupdusuid ;
         gxTv_SdtVisita_Visupdusunome = sdt.gxTv_SdtVisita_Visupdusunome ;
         gxTv_SdtVisita_Visdata = sdt.gxTv_SdtVisita_Visdata ;
         gxTv_SdtVisita_Vishora = sdt.gxTv_SdtVisita_Vishora ;
         gxTv_SdtVisita_Visdatahora = sdt.gxTv_SdtVisita_Visdatahora ;
         gxTv_SdtVisita_Visdatafim = sdt.gxTv_SdtVisita_Visdatafim ;
         gxTv_SdtVisita_Vishorafim = sdt.gxTv_SdtVisita_Vishorafim ;
         gxTv_SdtVisita_Visdatahorafim = sdt.gxTv_SdtVisita_Visdatahorafim ;
         gxTv_SdtVisita_Vistipoid = sdt.gxTv_SdtVisita_Vistipoid ;
         gxTv_SdtVisita_Vistiposigla = sdt.gxTv_SdtVisita_Vistiposigla ;
         gxTv_SdtVisita_Vistiponome = sdt.gxTv_SdtVisita_Vistiponome ;
         gxTv_SdtVisita_Visnegid = sdt.gxTv_SdtVisita_Visnegid ;
         gxTv_SdtVisita_Visnegcodigo = sdt.gxTv_SdtVisita_Visnegcodigo ;
         gxTv_SdtVisita_Visnegassunto = sdt.gxTv_SdtVisita_Visnegassunto ;
         gxTv_SdtVisita_Visnegvalor = sdt.gxTv_SdtVisita_Visnegvalor ;
         gxTv_SdtVisita_Visnegcliid = sdt.gxTv_SdtVisita_Visnegcliid ;
         gxTv_SdtVisita_Visnegclinomefamiliar = sdt.gxTv_SdtVisita_Visnegclinomefamiliar ;
         gxTv_SdtVisita_Visnegcpjid = sdt.gxTv_SdtVisita_Visnegcpjid ;
         gxTv_SdtVisita_Visnegcpjnomfan = sdt.gxTv_SdtVisita_Visnegcpjnomfan ;
         gxTv_SdtVisita_Visnegcpjrazsocial = sdt.gxTv_SdtVisita_Visnegcpjrazsocial ;
         gxTv_SdtVisita_Visngfseq = sdt.gxTv_SdtVisita_Visngfseq ;
         gxTv_SdtVisita_Visngfiteid = sdt.gxTv_SdtVisita_Visngfiteid ;
         gxTv_SdtVisita_Visngfitenome = sdt.gxTv_SdtVisita_Visngfitenome ;
         gxTv_SdtVisita_Visassunto = sdt.gxTv_SdtVisita_Visassunto ;
         gxTv_SdtVisita_Visdescricao = sdt.gxTv_SdtVisita_Visdescricao ;
         gxTv_SdtVisita_Vislink = sdt.gxTv_SdtVisita_Vislink ;
         gxTv_SdtVisita_Vissituacao = sdt.gxTv_SdtVisita_Vissituacao ;
         gxTv_SdtVisita_Visdel = sdt.gxTv_SdtVisita_Visdel ;
         gxTv_SdtVisita_Visdeldatahora = sdt.gxTv_SdtVisita_Visdeldatahora ;
         gxTv_SdtVisita_Visdeldata = sdt.gxTv_SdtVisita_Visdeldata ;
         gxTv_SdtVisita_Visdelhora = sdt.gxTv_SdtVisita_Visdelhora ;
         gxTv_SdtVisita_Visdelusuid = sdt.gxTv_SdtVisita_Visdelusuid ;
         gxTv_SdtVisita_Visdelusunome = sdt.gxTv_SdtVisita_Visdelusunome ;
         gxTv_SdtVisita_Mode = sdt.gxTv_SdtVisita_Mode ;
         gxTv_SdtVisita_Initialized = sdt.gxTv_SdtVisita_Initialized ;
         gxTv_SdtVisita_Visid_Z = sdt.gxTv_SdtVisita_Visid_Z ;
         gxTv_SdtVisita_Vispaiid_Z = sdt.gxTv_SdtVisita_Vispaiid_Z ;
         gxTv_SdtVisita_Vispaidata_Z = sdt.gxTv_SdtVisita_Vispaidata_Z ;
         gxTv_SdtVisita_Vispaihora_Z = sdt.gxTv_SdtVisita_Vispaihora_Z ;
         gxTv_SdtVisita_Vispaidatahora_Z = sdt.gxTv_SdtVisita_Vispaidatahora_Z ;
         gxTv_SdtVisita_Vispaiassunto_Z = sdt.gxTv_SdtVisita_Vispaiassunto_Z ;
         gxTv_SdtVisita_Visinsdata_Z = sdt.gxTv_SdtVisita_Visinsdata_Z ;
         gxTv_SdtVisita_Visinshora_Z = sdt.gxTv_SdtVisita_Visinshora_Z ;
         gxTv_SdtVisita_Visinsdatahora_Z = sdt.gxTv_SdtVisita_Visinsdatahora_Z ;
         gxTv_SdtVisita_Visinsusuid_Z = sdt.gxTv_SdtVisita_Visinsusuid_Z ;
         gxTv_SdtVisita_Visinsusunome_Z = sdt.gxTv_SdtVisita_Visinsusunome_Z ;
         gxTv_SdtVisita_Visupddata_Z = sdt.gxTv_SdtVisita_Visupddata_Z ;
         gxTv_SdtVisita_Visupdhora_Z = sdt.gxTv_SdtVisita_Visupdhora_Z ;
         gxTv_SdtVisita_Visupddatahora_Z = sdt.gxTv_SdtVisita_Visupddatahora_Z ;
         gxTv_SdtVisita_Visupdusuid_Z = sdt.gxTv_SdtVisita_Visupdusuid_Z ;
         gxTv_SdtVisita_Visupdusunome_Z = sdt.gxTv_SdtVisita_Visupdusunome_Z ;
         gxTv_SdtVisita_Visdata_Z = sdt.gxTv_SdtVisita_Visdata_Z ;
         gxTv_SdtVisita_Vishora_Z = sdt.gxTv_SdtVisita_Vishora_Z ;
         gxTv_SdtVisita_Visdatahora_Z = sdt.gxTv_SdtVisita_Visdatahora_Z ;
         gxTv_SdtVisita_Visdatafim_Z = sdt.gxTv_SdtVisita_Visdatafim_Z ;
         gxTv_SdtVisita_Vishorafim_Z = sdt.gxTv_SdtVisita_Vishorafim_Z ;
         gxTv_SdtVisita_Visdatahorafim_Z = sdt.gxTv_SdtVisita_Visdatahorafim_Z ;
         gxTv_SdtVisita_Vistipoid_Z = sdt.gxTv_SdtVisita_Vistipoid_Z ;
         gxTv_SdtVisita_Vistiposigla_Z = sdt.gxTv_SdtVisita_Vistiposigla_Z ;
         gxTv_SdtVisita_Vistiponome_Z = sdt.gxTv_SdtVisita_Vistiponome_Z ;
         gxTv_SdtVisita_Visnegid_Z = sdt.gxTv_SdtVisita_Visnegid_Z ;
         gxTv_SdtVisita_Visnegcodigo_Z = sdt.gxTv_SdtVisita_Visnegcodigo_Z ;
         gxTv_SdtVisita_Visnegassunto_Z = sdt.gxTv_SdtVisita_Visnegassunto_Z ;
         gxTv_SdtVisita_Visnegvalor_Z = sdt.gxTv_SdtVisita_Visnegvalor_Z ;
         gxTv_SdtVisita_Visnegcliid_Z = sdt.gxTv_SdtVisita_Visnegcliid_Z ;
         gxTv_SdtVisita_Visnegclinomefamiliar_Z = sdt.gxTv_SdtVisita_Visnegclinomefamiliar_Z ;
         gxTv_SdtVisita_Visnegcpjid_Z = sdt.gxTv_SdtVisita_Visnegcpjid_Z ;
         gxTv_SdtVisita_Visnegcpjnomfan_Z = sdt.gxTv_SdtVisita_Visnegcpjnomfan_Z ;
         gxTv_SdtVisita_Visnegcpjrazsocial_Z = sdt.gxTv_SdtVisita_Visnegcpjrazsocial_Z ;
         gxTv_SdtVisita_Visngfseq_Z = sdt.gxTv_SdtVisita_Visngfseq_Z ;
         gxTv_SdtVisita_Visngfiteid_Z = sdt.gxTv_SdtVisita_Visngfiteid_Z ;
         gxTv_SdtVisita_Visngfitenome_Z = sdt.gxTv_SdtVisita_Visngfitenome_Z ;
         gxTv_SdtVisita_Visassunto_Z = sdt.gxTv_SdtVisita_Visassunto_Z ;
         gxTv_SdtVisita_Vislink_Z = sdt.gxTv_SdtVisita_Vislink_Z ;
         gxTv_SdtVisita_Vissituacao_Z = sdt.gxTv_SdtVisita_Vissituacao_Z ;
         gxTv_SdtVisita_Visdel_Z = sdt.gxTv_SdtVisita_Visdel_Z ;
         gxTv_SdtVisita_Visdeldatahora_Z = sdt.gxTv_SdtVisita_Visdeldatahora_Z ;
         gxTv_SdtVisita_Visdeldata_Z = sdt.gxTv_SdtVisita_Visdeldata_Z ;
         gxTv_SdtVisita_Visdelhora_Z = sdt.gxTv_SdtVisita_Visdelhora_Z ;
         gxTv_SdtVisita_Visdelusuid_Z = sdt.gxTv_SdtVisita_Visdelusuid_Z ;
         gxTv_SdtVisita_Visdelusunome_Z = sdt.gxTv_SdtVisita_Visdelusunome_Z ;
         gxTv_SdtVisita_Vispaiid_N = sdt.gxTv_SdtVisita_Vispaiid_N ;
         gxTv_SdtVisita_Visinsusuid_N = sdt.gxTv_SdtVisita_Visinsusuid_N ;
         gxTv_SdtVisita_Visinsusunome_N = sdt.gxTv_SdtVisita_Visinsusunome_N ;
         gxTv_SdtVisita_Visupddata_N = sdt.gxTv_SdtVisita_Visupddata_N ;
         gxTv_SdtVisita_Visupdhora_N = sdt.gxTv_SdtVisita_Visupdhora_N ;
         gxTv_SdtVisita_Visupddatahora_N = sdt.gxTv_SdtVisita_Visupddatahora_N ;
         gxTv_SdtVisita_Visupdusuid_N = sdt.gxTv_SdtVisita_Visupdusuid_N ;
         gxTv_SdtVisita_Visupdusunome_N = sdt.gxTv_SdtVisita_Visupdusunome_N ;
         gxTv_SdtVisita_Visdatafim_N = sdt.gxTv_SdtVisita_Visdatafim_N ;
         gxTv_SdtVisita_Vishorafim_N = sdt.gxTv_SdtVisita_Vishorafim_N ;
         gxTv_SdtVisita_Visdatahorafim_N = sdt.gxTv_SdtVisita_Visdatahorafim_N ;
         gxTv_SdtVisita_Visnegid_N = sdt.gxTv_SdtVisita_Visnegid_N ;
         gxTv_SdtVisita_Visngfseq_N = sdt.gxTv_SdtVisita_Visngfseq_N ;
         gxTv_SdtVisita_Visdescricao_N = sdt.gxTv_SdtVisita_Visdescricao_N ;
         gxTv_SdtVisita_Vislink_N = sdt.gxTv_SdtVisita_Vislink_N ;
         gxTv_SdtVisita_Visdeldatahora_N = sdt.gxTv_SdtVisita_Visdeldatahora_N ;
         gxTv_SdtVisita_Visdeldata_N = sdt.gxTv_SdtVisita_Visdeldata_N ;
         gxTv_SdtVisita_Visdelhora_N = sdt.gxTv_SdtVisita_Visdelhora_N ;
         gxTv_SdtVisita_Visdelusuid_N = sdt.gxTv_SdtVisita_Visdelusuid_N ;
         gxTv_SdtVisita_Visdelusunome_N = sdt.gxTv_SdtVisita_Visdelusunome_N ;
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
         AddObjectProperty("VisID", gxTv_SdtVisita_Visid, false, includeNonInitialized);
         AddObjectProperty("VisPaiID", gxTv_SdtVisita_Vispaiid, false, includeNonInitialized);
         AddObjectProperty("VisPaiID_N", gxTv_SdtVisita_Vispaiid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Vispaidata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Vispaidata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Vispaidata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("VisPaiData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Vispaihora;
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
         AddObjectProperty("VisPaiHora", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Vispaidatahora;
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
         AddObjectProperty("VisPaiDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisPaiAssunto", gxTv_SdtVisita_Vispaiassunto, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visinsdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("VisInsData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Visinshora;
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
         AddObjectProperty("VisInsHora", sDateCnv, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtVisita_Visinsdatahora;
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
         AddObjectProperty("VisInsDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisInsUsuID", gxTv_SdtVisita_Visinsusuid, false, includeNonInitialized);
         AddObjectProperty("VisInsUsuID_N", gxTv_SdtVisita_Visinsusuid_N, false, includeNonInitialized);
         AddObjectProperty("VisInsUsuNome", gxTv_SdtVisita_Visinsusunome, false, includeNonInitialized);
         AddObjectProperty("VisInsUsuNome_N", gxTv_SdtVisita_Visinsusunome_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visupddata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("VisUpdData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisUpdData_N", gxTv_SdtVisita_Visupddata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Visupdhora;
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
         AddObjectProperty("VisUpdHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisUpdHora_N", gxTv_SdtVisita_Visupdhora_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtVisita_Visupddatahora;
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
         AddObjectProperty("VisUpdDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisUpdDataHora_N", gxTv_SdtVisita_Visupddatahora_N, false, includeNonInitialized);
         AddObjectProperty("VisUpdUsuID", gxTv_SdtVisita_Visupdusuid, false, includeNonInitialized);
         AddObjectProperty("VisUpdUsuID_N", gxTv_SdtVisita_Visupdusuid_N, false, includeNonInitialized);
         AddObjectProperty("VisUpdUsuNome", gxTv_SdtVisita_Visupdusunome, false, includeNonInitialized);
         AddObjectProperty("VisUpdUsuNome_N", gxTv_SdtVisita_Visupdusunome_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("VisData", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Vishora;
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
         AddObjectProperty("VisHora", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Visdatahora;
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
         AddObjectProperty("VisDataHora", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visdatafim)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visdatafim)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visdatafim)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("VisDataFim", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisDataFim_N", gxTv_SdtVisita_Visdatafim_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Vishorafim;
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
         AddObjectProperty("VisHoraFim", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisHoraFim_N", gxTv_SdtVisita_Vishorafim_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Visdatahorafim;
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
         AddObjectProperty("VisDataHoraFim", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisDataHoraFim_N", gxTv_SdtVisita_Visdatahorafim_N, false, includeNonInitialized);
         AddObjectProperty("VisTipoID", gxTv_SdtVisita_Vistipoid, false, includeNonInitialized);
         AddObjectProperty("VisTipoSigla", gxTv_SdtVisita_Vistiposigla, false, includeNonInitialized);
         AddObjectProperty("VisTipoNome", gxTv_SdtVisita_Vistiponome, false, includeNonInitialized);
         AddObjectProperty("VisNegID", gxTv_SdtVisita_Visnegid, false, includeNonInitialized);
         AddObjectProperty("VisNegID_N", gxTv_SdtVisita_Visnegid_N, false, includeNonInitialized);
         AddObjectProperty("VisNegCodigo", gxTv_SdtVisita_Visnegcodigo, false, includeNonInitialized);
         AddObjectProperty("VisNegAssunto", gxTv_SdtVisita_Visnegassunto, false, includeNonInitialized);
         AddObjectProperty("VisNegValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtVisita_Visnegvalor, 16, 2)), false, includeNonInitialized);
         AddObjectProperty("VisNegCliID", gxTv_SdtVisita_Visnegcliid, false, includeNonInitialized);
         AddObjectProperty("VisNegCliNomeFamiliar", gxTv_SdtVisita_Visnegclinomefamiliar, false, includeNonInitialized);
         AddObjectProperty("VisNegCpjID", gxTv_SdtVisita_Visnegcpjid, false, includeNonInitialized);
         AddObjectProperty("VisNegCpjNomFan", gxTv_SdtVisita_Visnegcpjnomfan, false, includeNonInitialized);
         AddObjectProperty("VisNegCpjRazSocial", gxTv_SdtVisita_Visnegcpjrazsocial, false, includeNonInitialized);
         AddObjectProperty("VisNgfSeq", gxTv_SdtVisita_Visngfseq, false, includeNonInitialized);
         AddObjectProperty("VisNgfSeq_N", gxTv_SdtVisita_Visngfseq_N, false, includeNonInitialized);
         AddObjectProperty("VisNgfIteID", gxTv_SdtVisita_Visngfiteid, false, includeNonInitialized);
         AddObjectProperty("VisNgfIteNome", gxTv_SdtVisita_Visngfitenome, false, includeNonInitialized);
         AddObjectProperty("VisAssunto", gxTv_SdtVisita_Visassunto, false, includeNonInitialized);
         AddObjectProperty("VisDescricao", gxTv_SdtVisita_Visdescricao, false, includeNonInitialized);
         AddObjectProperty("VisDescricao_N", gxTv_SdtVisita_Visdescricao_N, false, includeNonInitialized);
         AddObjectProperty("VisLink", gxTv_SdtVisita_Vislink, false, includeNonInitialized);
         AddObjectProperty("VisLink_N", gxTv_SdtVisita_Vislink_N, false, includeNonInitialized);
         AddObjectProperty("VisSituacao", gxTv_SdtVisita_Vissituacao, false, includeNonInitialized);
         AddObjectProperty("VisDel", gxTv_SdtVisita_Visdel, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtVisita_Visdeldatahora;
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
         AddObjectProperty("VisDelDataHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisDelDataHora_N", gxTv_SdtVisita_Visdeldatahora_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Visdeldata;
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
         AddObjectProperty("VisDelData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisDelData_N", gxTv_SdtVisita_Visdeldata_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtVisita_Visdelhora;
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
         AddObjectProperty("VisDelHora", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("VisDelHora_N", gxTv_SdtVisita_Visdelhora_N, false, includeNonInitialized);
         AddObjectProperty("VisDelUsuID", gxTv_SdtVisita_Visdelusuid, false, includeNonInitialized);
         AddObjectProperty("VisDelUsuID_N", gxTv_SdtVisita_Visdelusuid_N, false, includeNonInitialized);
         AddObjectProperty("VisDelUsuNome", gxTv_SdtVisita_Visdelusunome, false, includeNonInitialized);
         AddObjectProperty("VisDelUsuNome_N", gxTv_SdtVisita_Visdelusunome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtVisita_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtVisita_Initialized, false, includeNonInitialized);
            AddObjectProperty("VisID_Z", gxTv_SdtVisita_Visid_Z, false, includeNonInitialized);
            AddObjectProperty("VisPaiID_Z", gxTv_SdtVisita_Vispaiid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Vispaidata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Vispaidata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Vispaidata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("VisPaiData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Vispaihora_Z;
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
            AddObjectProperty("VisPaiHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Vispaidatahora_Z;
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
            AddObjectProperty("VisPaiDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VisPaiAssunto_Z", gxTv_SdtVisita_Vispaiassunto_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visinsdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("VisInsData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Visinshora_Z;
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
            AddObjectProperty("VisInsHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtVisita_Visinsdatahora_Z;
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
            AddObjectProperty("VisInsDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VisInsUsuID_Z", gxTv_SdtVisita_Visinsusuid_Z, false, includeNonInitialized);
            AddObjectProperty("VisInsUsuNome_Z", gxTv_SdtVisita_Visinsusunome_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visupddata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("VisUpdData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Visupdhora_Z;
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
            AddObjectProperty("VisUpdHora_Z", sDateCnv, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtVisita_Visupddatahora_Z;
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
            AddObjectProperty("VisUpdDataHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VisUpdUsuID_Z", gxTv_SdtVisita_Visupdusuid_Z, false, includeNonInitialized);
            AddObjectProperty("VisUpdUsuNome_Z", gxTv_SdtVisita_Visupdusunome_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("VisData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Vishora_Z;
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
            AddObjectProperty("VisHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Visdatahora_Z;
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
            AddObjectProperty("VisDataHora_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtVisita_Visdatafim_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtVisita_Visdatafim_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtVisita_Visdatafim_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("VisDataFim_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Vishorafim_Z;
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
            AddObjectProperty("VisHoraFim_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Visdatahorafim_Z;
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
            AddObjectProperty("VisDataHoraFim_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VisTipoID_Z", gxTv_SdtVisita_Vistipoid_Z, false, includeNonInitialized);
            AddObjectProperty("VisTipoSigla_Z", gxTv_SdtVisita_Vistiposigla_Z, false, includeNonInitialized);
            AddObjectProperty("VisTipoNome_Z", gxTv_SdtVisita_Vistiponome_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegID_Z", gxTv_SdtVisita_Visnegid_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegCodigo_Z", gxTv_SdtVisita_Visnegcodigo_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegAssunto_Z", gxTv_SdtVisita_Visnegassunto_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtVisita_Visnegvalor_Z, 16, 2)), false, includeNonInitialized);
            AddObjectProperty("VisNegCliID_Z", gxTv_SdtVisita_Visnegcliid_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegCliNomeFamiliar_Z", gxTv_SdtVisita_Visnegclinomefamiliar_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegCpjID_Z", gxTv_SdtVisita_Visnegcpjid_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegCpjNomFan_Z", gxTv_SdtVisita_Visnegcpjnomfan_Z, false, includeNonInitialized);
            AddObjectProperty("VisNegCpjRazSocial_Z", gxTv_SdtVisita_Visnegcpjrazsocial_Z, false, includeNonInitialized);
            AddObjectProperty("VisNgfSeq_Z", gxTv_SdtVisita_Visngfseq_Z, false, includeNonInitialized);
            AddObjectProperty("VisNgfIteID_Z", gxTv_SdtVisita_Visngfiteid_Z, false, includeNonInitialized);
            AddObjectProperty("VisNgfIteNome_Z", gxTv_SdtVisita_Visngfitenome_Z, false, includeNonInitialized);
            AddObjectProperty("VisAssunto_Z", gxTv_SdtVisita_Visassunto_Z, false, includeNonInitialized);
            AddObjectProperty("VisLink_Z", gxTv_SdtVisita_Vislink_Z, false, includeNonInitialized);
            AddObjectProperty("VisSituacao_Z", gxTv_SdtVisita_Vissituacao_Z, false, includeNonInitialized);
            AddObjectProperty("VisDel_Z", gxTv_SdtVisita_Visdel_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtVisita_Visdeldatahora_Z;
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
            AddObjectProperty("VisDelDataHora_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Visdeldata_Z;
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
            AddObjectProperty("VisDelData_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtVisita_Visdelhora_Z;
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
            AddObjectProperty("VisDelHora_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("VisDelUsuID_Z", gxTv_SdtVisita_Visdelusuid_Z, false, includeNonInitialized);
            AddObjectProperty("VisDelUsuNome_Z", gxTv_SdtVisita_Visdelusunome_Z, false, includeNonInitialized);
            AddObjectProperty("VisPaiID_N", gxTv_SdtVisita_Vispaiid_N, false, includeNonInitialized);
            AddObjectProperty("VisInsUsuID_N", gxTv_SdtVisita_Visinsusuid_N, false, includeNonInitialized);
            AddObjectProperty("VisInsUsuNome_N", gxTv_SdtVisita_Visinsusunome_N, false, includeNonInitialized);
            AddObjectProperty("VisUpdData_N", gxTv_SdtVisita_Visupddata_N, false, includeNonInitialized);
            AddObjectProperty("VisUpdHora_N", gxTv_SdtVisita_Visupdhora_N, false, includeNonInitialized);
            AddObjectProperty("VisUpdDataHora_N", gxTv_SdtVisita_Visupddatahora_N, false, includeNonInitialized);
            AddObjectProperty("VisUpdUsuID_N", gxTv_SdtVisita_Visupdusuid_N, false, includeNonInitialized);
            AddObjectProperty("VisUpdUsuNome_N", gxTv_SdtVisita_Visupdusunome_N, false, includeNonInitialized);
            AddObjectProperty("VisDataFim_N", gxTv_SdtVisita_Visdatafim_N, false, includeNonInitialized);
            AddObjectProperty("VisHoraFim_N", gxTv_SdtVisita_Vishorafim_N, false, includeNonInitialized);
            AddObjectProperty("VisDataHoraFim_N", gxTv_SdtVisita_Visdatahorafim_N, false, includeNonInitialized);
            AddObjectProperty("VisNegID_N", gxTv_SdtVisita_Visnegid_N, false, includeNonInitialized);
            AddObjectProperty("VisNgfSeq_N", gxTv_SdtVisita_Visngfseq_N, false, includeNonInitialized);
            AddObjectProperty("VisDescricao_N", gxTv_SdtVisita_Visdescricao_N, false, includeNonInitialized);
            AddObjectProperty("VisLink_N", gxTv_SdtVisita_Vislink_N, false, includeNonInitialized);
            AddObjectProperty("VisDelDataHora_N", gxTv_SdtVisita_Visdeldatahora_N, false, includeNonInitialized);
            AddObjectProperty("VisDelData_N", gxTv_SdtVisita_Visdeldata_N, false, includeNonInitialized);
            AddObjectProperty("VisDelHora_N", gxTv_SdtVisita_Visdelhora_N, false, includeNonInitialized);
            AddObjectProperty("VisDelUsuID_N", gxTv_SdtVisita_Visdelusuid_N, false, includeNonInitialized);
            AddObjectProperty("VisDelUsuNome_N", gxTv_SdtVisita_Visdelusunome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.core.SdtVisita sdt )
      {
         if ( sdt.IsDirty("VisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visid = sdt.gxTv_SdtVisita_Visid ;
         }
         if ( sdt.IsDirty("VisPaiID") )
         {
            gxTv_SdtVisita_Vispaiid_N = (short)(sdt.gxTv_SdtVisita_Vispaiid_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaiid = sdt.gxTv_SdtVisita_Vispaiid ;
         }
         if ( sdt.IsDirty("VisPaiData") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaidata = sdt.gxTv_SdtVisita_Vispaidata ;
         }
         if ( sdt.IsDirty("VisPaiHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaihora = sdt.gxTv_SdtVisita_Vispaihora ;
         }
         if ( sdt.IsDirty("VisPaiDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaidatahora = sdt.gxTv_SdtVisita_Vispaidatahora ;
         }
         if ( sdt.IsDirty("VisPaiAssunto") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaiassunto = sdt.gxTv_SdtVisita_Vispaiassunto ;
         }
         if ( sdt.IsDirty("VisInsData") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsdata = sdt.gxTv_SdtVisita_Visinsdata ;
         }
         if ( sdt.IsDirty("VisInsHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinshora = sdt.gxTv_SdtVisita_Visinshora ;
         }
         if ( sdt.IsDirty("VisInsDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsdatahora = sdt.gxTv_SdtVisita_Visinsdatahora ;
         }
         if ( sdt.IsDirty("VisInsUsuID") )
         {
            gxTv_SdtVisita_Visinsusuid_N = (short)(sdt.gxTv_SdtVisita_Visinsusuid_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusuid = sdt.gxTv_SdtVisita_Visinsusuid ;
         }
         if ( sdt.IsDirty("VisInsUsuNome") )
         {
            gxTv_SdtVisita_Visinsusunome_N = (short)(sdt.gxTv_SdtVisita_Visinsusunome_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusunome = sdt.gxTv_SdtVisita_Visinsusunome ;
         }
         if ( sdt.IsDirty("VisUpdData") )
         {
            gxTv_SdtVisita_Visupddata_N = (short)(sdt.gxTv_SdtVisita_Visupddata_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddata = sdt.gxTv_SdtVisita_Visupddata ;
         }
         if ( sdt.IsDirty("VisUpdHora") )
         {
            gxTv_SdtVisita_Visupdhora_N = (short)(sdt.gxTv_SdtVisita_Visupdhora_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdhora = sdt.gxTv_SdtVisita_Visupdhora ;
         }
         if ( sdt.IsDirty("VisUpdDataHora") )
         {
            gxTv_SdtVisita_Visupddatahora_N = (short)(sdt.gxTv_SdtVisita_Visupddatahora_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddatahora = sdt.gxTv_SdtVisita_Visupddatahora ;
         }
         if ( sdt.IsDirty("VisUpdUsuID") )
         {
            gxTv_SdtVisita_Visupdusuid_N = (short)(sdt.gxTv_SdtVisita_Visupdusuid_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusuid = sdt.gxTv_SdtVisita_Visupdusuid ;
         }
         if ( sdt.IsDirty("VisUpdUsuNome") )
         {
            gxTv_SdtVisita_Visupdusunome_N = (short)(sdt.gxTv_SdtVisita_Visupdusunome_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusunome = sdt.gxTv_SdtVisita_Visupdusunome ;
         }
         if ( sdt.IsDirty("VisData") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdata = sdt.gxTv_SdtVisita_Visdata ;
         }
         if ( sdt.IsDirty("VisHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vishora = sdt.gxTv_SdtVisita_Vishora ;
         }
         if ( sdt.IsDirty("VisDataHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatahora = sdt.gxTv_SdtVisita_Visdatahora ;
         }
         if ( sdt.IsDirty("VisDataFim") )
         {
            gxTv_SdtVisita_Visdatafim_N = (short)(sdt.gxTv_SdtVisita_Visdatafim_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatafim = sdt.gxTv_SdtVisita_Visdatafim ;
         }
         if ( sdt.IsDirty("VisHoraFim") )
         {
            gxTv_SdtVisita_Vishorafim_N = (short)(sdt.gxTv_SdtVisita_Vishorafim_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Vishorafim = sdt.gxTv_SdtVisita_Vishorafim ;
         }
         if ( sdt.IsDirty("VisDataHoraFim") )
         {
            gxTv_SdtVisita_Visdatahorafim_N = (short)(sdt.gxTv_SdtVisita_Visdatahorafim_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatahorafim = sdt.gxTv_SdtVisita_Visdatahorafim ;
         }
         if ( sdt.IsDirty("VisTipoID") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistipoid = sdt.gxTv_SdtVisita_Vistipoid ;
         }
         if ( sdt.IsDirty("VisTipoSigla") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistiposigla = sdt.gxTv_SdtVisita_Vistiposigla ;
         }
         if ( sdt.IsDirty("VisTipoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistiponome = sdt.gxTv_SdtVisita_Vistiponome ;
         }
         if ( sdt.IsDirty("VisNegID") )
         {
            gxTv_SdtVisita_Visnegid_N = (short)(sdt.gxTv_SdtVisita_Visnegid_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegid = sdt.gxTv_SdtVisita_Visnegid ;
         }
         if ( sdt.IsDirty("VisNegCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcodigo = sdt.gxTv_SdtVisita_Visnegcodigo ;
         }
         if ( sdt.IsDirty("VisNegAssunto") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegassunto = sdt.gxTv_SdtVisita_Visnegassunto ;
         }
         if ( sdt.IsDirty("VisNegValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegvalor = sdt.gxTv_SdtVisita_Visnegvalor ;
         }
         if ( sdt.IsDirty("VisNegCliID") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcliid = sdt.gxTv_SdtVisita_Visnegcliid ;
         }
         if ( sdt.IsDirty("VisNegCliNomeFamiliar") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegclinomefamiliar = sdt.gxTv_SdtVisita_Visnegclinomefamiliar ;
         }
         if ( sdt.IsDirty("VisNegCpjID") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjid = sdt.gxTv_SdtVisita_Visnegcpjid ;
         }
         if ( sdt.IsDirty("VisNegCpjNomFan") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjnomfan = sdt.gxTv_SdtVisita_Visnegcpjnomfan ;
         }
         if ( sdt.IsDirty("VisNegCpjRazSocial") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjrazsocial = sdt.gxTv_SdtVisita_Visnegcpjrazsocial ;
         }
         if ( sdt.IsDirty("VisNgfSeq") )
         {
            gxTv_SdtVisita_Visngfseq_N = (short)(sdt.gxTv_SdtVisita_Visngfseq_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfseq = sdt.gxTv_SdtVisita_Visngfseq ;
         }
         if ( sdt.IsDirty("VisNgfIteID") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfiteid = sdt.gxTv_SdtVisita_Visngfiteid ;
         }
         if ( sdt.IsDirty("VisNgfIteNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfitenome = sdt.gxTv_SdtVisita_Visngfitenome ;
         }
         if ( sdt.IsDirty("VisAssunto") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visassunto = sdt.gxTv_SdtVisita_Visassunto ;
         }
         if ( sdt.IsDirty("VisDescricao") )
         {
            gxTv_SdtVisita_Visdescricao_N = (short)(sdt.gxTv_SdtVisita_Visdescricao_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdescricao = sdt.gxTv_SdtVisita_Visdescricao ;
         }
         if ( sdt.IsDirty("VisLink") )
         {
            gxTv_SdtVisita_Vislink_N = (short)(sdt.gxTv_SdtVisita_Vislink_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Vislink = sdt.gxTv_SdtVisita_Vislink ;
         }
         if ( sdt.IsDirty("VisSituacao") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vissituacao = sdt.gxTv_SdtVisita_Vissituacao ;
         }
         if ( sdt.IsDirty("VisDel") )
         {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdel = sdt.gxTv_SdtVisita_Visdel ;
         }
         if ( sdt.IsDirty("VisDelDataHora") )
         {
            gxTv_SdtVisita_Visdeldatahora_N = (short)(sdt.gxTv_SdtVisita_Visdeldatahora_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldatahora = sdt.gxTv_SdtVisita_Visdeldatahora ;
         }
         if ( sdt.IsDirty("VisDelData") )
         {
            gxTv_SdtVisita_Visdeldata_N = (short)(sdt.gxTv_SdtVisita_Visdeldata_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldata = sdt.gxTv_SdtVisita_Visdeldata ;
         }
         if ( sdt.IsDirty("VisDelHora") )
         {
            gxTv_SdtVisita_Visdelhora_N = (short)(sdt.gxTv_SdtVisita_Visdelhora_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelhora = sdt.gxTv_SdtVisita_Visdelhora ;
         }
         if ( sdt.IsDirty("VisDelUsuID") )
         {
            gxTv_SdtVisita_Visdelusuid_N = (short)(sdt.gxTv_SdtVisita_Visdelusuid_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusuid = sdt.gxTv_SdtVisita_Visdelusuid ;
         }
         if ( sdt.IsDirty("VisDelUsuNome") )
         {
            gxTv_SdtVisita_Visdelusunome_N = (short)(sdt.gxTv_SdtVisita_Visdelusunome_N);
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusunome = sdt.gxTv_SdtVisita_Visdelusunome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "VisID" )]
      [  XmlElement( ElementName = "VisID"   )]
      public Guid gxTpr_Visid
      {
         get {
            return gxTv_SdtVisita_Visid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtVisita_Visid != value )
            {
               gxTv_SdtVisita_Mode = "INS";
               this.gxTv_SdtVisita_Visid_Z_SetNull( );
               this.gxTv_SdtVisita_Vispaiid_Z_SetNull( );
               this.gxTv_SdtVisita_Vispaidata_Z_SetNull( );
               this.gxTv_SdtVisita_Vispaihora_Z_SetNull( );
               this.gxTv_SdtVisita_Vispaidatahora_Z_SetNull( );
               this.gxTv_SdtVisita_Vispaiassunto_Z_SetNull( );
               this.gxTv_SdtVisita_Visinsdata_Z_SetNull( );
               this.gxTv_SdtVisita_Visinshora_Z_SetNull( );
               this.gxTv_SdtVisita_Visinsdatahora_Z_SetNull( );
               this.gxTv_SdtVisita_Visinsusuid_Z_SetNull( );
               this.gxTv_SdtVisita_Visinsusunome_Z_SetNull( );
               this.gxTv_SdtVisita_Visupddata_Z_SetNull( );
               this.gxTv_SdtVisita_Visupdhora_Z_SetNull( );
               this.gxTv_SdtVisita_Visupddatahora_Z_SetNull( );
               this.gxTv_SdtVisita_Visupdusuid_Z_SetNull( );
               this.gxTv_SdtVisita_Visupdusunome_Z_SetNull( );
               this.gxTv_SdtVisita_Visdata_Z_SetNull( );
               this.gxTv_SdtVisita_Vishora_Z_SetNull( );
               this.gxTv_SdtVisita_Visdatahora_Z_SetNull( );
               this.gxTv_SdtVisita_Visdatafim_Z_SetNull( );
               this.gxTv_SdtVisita_Vishorafim_Z_SetNull( );
               this.gxTv_SdtVisita_Visdatahorafim_Z_SetNull( );
               this.gxTv_SdtVisita_Vistipoid_Z_SetNull( );
               this.gxTv_SdtVisita_Vistiposigla_Z_SetNull( );
               this.gxTv_SdtVisita_Vistiponome_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegid_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegcodigo_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegassunto_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegvalor_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegcliid_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegclinomefamiliar_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegcpjid_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegcpjnomfan_Z_SetNull( );
               this.gxTv_SdtVisita_Visnegcpjrazsocial_Z_SetNull( );
               this.gxTv_SdtVisita_Visngfseq_Z_SetNull( );
               this.gxTv_SdtVisita_Visngfiteid_Z_SetNull( );
               this.gxTv_SdtVisita_Visngfitenome_Z_SetNull( );
               this.gxTv_SdtVisita_Visassunto_Z_SetNull( );
               this.gxTv_SdtVisita_Vislink_Z_SetNull( );
               this.gxTv_SdtVisita_Vissituacao_Z_SetNull( );
               this.gxTv_SdtVisita_Visdel_Z_SetNull( );
               this.gxTv_SdtVisita_Visdeldatahora_Z_SetNull( );
               this.gxTv_SdtVisita_Visdeldata_Z_SetNull( );
               this.gxTv_SdtVisita_Visdelhora_Z_SetNull( );
               this.gxTv_SdtVisita_Visdelusuid_Z_SetNull( );
               this.gxTv_SdtVisita_Visdelusunome_Z_SetNull( );
            }
            gxTv_SdtVisita_Visid = value;
            SetDirty("Visid");
         }

      }

      [  SoapElement( ElementName = "VisPaiID" )]
      [  XmlElement( ElementName = "VisPaiID"   )]
      public Guid gxTpr_Vispaiid
      {
         get {
            return gxTv_SdtVisita_Vispaiid ;
         }

         set {
            gxTv_SdtVisita_Vispaiid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaiid = value;
            SetDirty("Vispaiid");
         }

      }

      public void gxTv_SdtVisita_Vispaiid_SetNull( )
      {
         gxTv_SdtVisita_Vispaiid_N = 1;
         gxTv_SdtVisita_Vispaiid = Guid.Empty;
         SetDirty("Vispaiid");
         return  ;
      }

      public bool gxTv_SdtVisita_Vispaiid_IsNull( )
      {
         return (gxTv_SdtVisita_Vispaiid_N==1) ;
      }

      [  SoapElement( ElementName = "VisPaiData" )]
      [  XmlElement( ElementName = "VisPaiData"  , IsNullable=true )]
      public string gxTpr_Vispaidata_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vispaidata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Vispaidata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Vispaidata = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vispaidata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vispaidata
      {
         get {
            return gxTv_SdtVisita_Vispaidata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaidata = value;
            SetDirty("Vispaidata");
         }

      }

      [  SoapElement( ElementName = "VisPaiHora" )]
      [  XmlElement( ElementName = "VisPaiHora"  , IsNullable=true )]
      public string gxTpr_Vispaihora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vispaihora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vispaihora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vispaihora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vispaihora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vispaihora
      {
         get {
            return gxTv_SdtVisita_Vispaihora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaihora = value;
            SetDirty("Vispaihora");
         }

      }

      [  SoapElement( ElementName = "VisPaiDataHora" )]
      [  XmlElement( ElementName = "VisPaiDataHora"  , IsNullable=true )]
      public string gxTpr_Vispaidatahora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vispaidatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vispaidatahora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vispaidatahora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vispaidatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vispaidatahora
      {
         get {
            return gxTv_SdtVisita_Vispaidatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaidatahora = value;
            SetDirty("Vispaidatahora");
         }

      }

      [  SoapElement( ElementName = "VisPaiAssunto" )]
      [  XmlElement( ElementName = "VisPaiAssunto"   )]
      public string gxTpr_Vispaiassunto
      {
         get {
            return gxTv_SdtVisita_Vispaiassunto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaiassunto = value;
            SetDirty("Vispaiassunto");
         }

      }

      [  SoapElement( ElementName = "VisInsData" )]
      [  XmlElement( ElementName = "VisInsData"  , IsNullable=true )]
      public string gxTpr_Visinsdata_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visinsdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visinsdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visinsdata = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visinsdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visinsdata
      {
         get {
            return gxTv_SdtVisita_Visinsdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsdata = value;
            SetDirty("Visinsdata");
         }

      }

      [  SoapElement( ElementName = "VisInsHora" )]
      [  XmlElement( ElementName = "VisInsHora"  , IsNullable=true )]
      public string gxTpr_Visinshora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visinshora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visinshora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visinshora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visinshora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visinshora
      {
         get {
            return gxTv_SdtVisita_Visinshora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinshora = value;
            SetDirty("Visinshora");
         }

      }

      [  SoapElement( ElementName = "VisInsDataHora" )]
      [  XmlElement( ElementName = "VisInsDataHora"  , IsNullable=true )]
      public string gxTpr_Visinsdatahora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visinsdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visinsdatahora, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visinsdatahora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visinsdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visinsdatahora
      {
         get {
            return gxTv_SdtVisita_Visinsdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsdatahora = value;
            SetDirty("Visinsdatahora");
         }

      }

      [  SoapElement( ElementName = "VisInsUsuID" )]
      [  XmlElement( ElementName = "VisInsUsuID"   )]
      public string gxTpr_Visinsusuid
      {
         get {
            return gxTv_SdtVisita_Visinsusuid ;
         }

         set {
            gxTv_SdtVisita_Visinsusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusuid = value;
            SetDirty("Visinsusuid");
         }

      }

      public void gxTv_SdtVisita_Visinsusuid_SetNull( )
      {
         gxTv_SdtVisita_Visinsusuid_N = 1;
         gxTv_SdtVisita_Visinsusuid = "";
         SetDirty("Visinsusuid");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsusuid_IsNull( )
      {
         return (gxTv_SdtVisita_Visinsusuid_N==1) ;
      }

      [  SoapElement( ElementName = "VisInsUsuNome" )]
      [  XmlElement( ElementName = "VisInsUsuNome"   )]
      public string gxTpr_Visinsusunome
      {
         get {
            return gxTv_SdtVisita_Visinsusunome ;
         }

         set {
            gxTv_SdtVisita_Visinsusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusunome = value;
            SetDirty("Visinsusunome");
         }

      }

      public void gxTv_SdtVisita_Visinsusunome_SetNull( )
      {
         gxTv_SdtVisita_Visinsusunome_N = 1;
         gxTv_SdtVisita_Visinsusunome = "";
         SetDirty("Visinsusunome");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsusunome_IsNull( )
      {
         return (gxTv_SdtVisita_Visinsusunome_N==1) ;
      }

      [  SoapElement( ElementName = "VisUpdData" )]
      [  XmlElement( ElementName = "VisUpdData"  , IsNullable=true )]
      public string gxTpr_Visupddata_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visupddata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visupddata).value ;
         }

         set {
            gxTv_SdtVisita_Visupddata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visupddata = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visupddata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visupddata
      {
         get {
            return gxTv_SdtVisita_Visupddata ;
         }

         set {
            gxTv_SdtVisita_Visupddata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddata = value;
            SetDirty("Visupddata");
         }

      }

      public void gxTv_SdtVisita_Visupddata_SetNull( )
      {
         gxTv_SdtVisita_Visupddata_N = 1;
         gxTv_SdtVisita_Visupddata = (DateTime)(DateTime.MinValue);
         SetDirty("Visupddata");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupddata_IsNull( )
      {
         return (gxTv_SdtVisita_Visupddata_N==1) ;
      }

      [  SoapElement( ElementName = "VisUpdHora" )]
      [  XmlElement( ElementName = "VisUpdHora"  , IsNullable=true )]
      public string gxTpr_Visupdhora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visupdhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visupdhora).value ;
         }

         set {
            gxTv_SdtVisita_Visupdhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visupdhora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visupdhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visupdhora
      {
         get {
            return gxTv_SdtVisita_Visupdhora ;
         }

         set {
            gxTv_SdtVisita_Visupdhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdhora = value;
            SetDirty("Visupdhora");
         }

      }

      public void gxTv_SdtVisita_Visupdhora_SetNull( )
      {
         gxTv_SdtVisita_Visupdhora_N = 1;
         gxTv_SdtVisita_Visupdhora = (DateTime)(DateTime.MinValue);
         SetDirty("Visupdhora");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdhora_IsNull( )
      {
         return (gxTv_SdtVisita_Visupdhora_N==1) ;
      }

      [  SoapElement( ElementName = "VisUpdDataHora" )]
      [  XmlElement( ElementName = "VisUpdDataHora"  , IsNullable=true )]
      public string gxTpr_Visupddatahora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visupddatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visupddatahora, null, true).value ;
         }

         set {
            gxTv_SdtVisita_Visupddatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visupddatahora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visupddatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visupddatahora
      {
         get {
            return gxTv_SdtVisita_Visupddatahora ;
         }

         set {
            gxTv_SdtVisita_Visupddatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddatahora = value;
            SetDirty("Visupddatahora");
         }

      }

      public void gxTv_SdtVisita_Visupddatahora_SetNull( )
      {
         gxTv_SdtVisita_Visupddatahora_N = 1;
         gxTv_SdtVisita_Visupddatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Visupddatahora");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupddatahora_IsNull( )
      {
         return (gxTv_SdtVisita_Visupddatahora_N==1) ;
      }

      [  SoapElement( ElementName = "VisUpdUsuID" )]
      [  XmlElement( ElementName = "VisUpdUsuID"   )]
      public string gxTpr_Visupdusuid
      {
         get {
            return gxTv_SdtVisita_Visupdusuid ;
         }

         set {
            gxTv_SdtVisita_Visupdusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusuid = value;
            SetDirty("Visupdusuid");
         }

      }

      public void gxTv_SdtVisita_Visupdusuid_SetNull( )
      {
         gxTv_SdtVisita_Visupdusuid_N = 1;
         gxTv_SdtVisita_Visupdusuid = "";
         SetDirty("Visupdusuid");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdusuid_IsNull( )
      {
         return (gxTv_SdtVisita_Visupdusuid_N==1) ;
      }

      [  SoapElement( ElementName = "VisUpdUsuNome" )]
      [  XmlElement( ElementName = "VisUpdUsuNome"   )]
      public string gxTpr_Visupdusunome
      {
         get {
            return gxTv_SdtVisita_Visupdusunome ;
         }

         set {
            gxTv_SdtVisita_Visupdusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusunome = value;
            SetDirty("Visupdusunome");
         }

      }

      public void gxTv_SdtVisita_Visupdusunome_SetNull( )
      {
         gxTv_SdtVisita_Visupdusunome_N = 1;
         gxTv_SdtVisita_Visupdusunome = "";
         SetDirty("Visupdusunome");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdusunome_IsNull( )
      {
         return (gxTv_SdtVisita_Visupdusunome_N==1) ;
      }

      [  SoapElement( ElementName = "VisData" )]
      [  XmlElement( ElementName = "VisData"  , IsNullable=true )]
      public string gxTpr_Visdata_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visdata).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visdata = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdata
      {
         get {
            return gxTv_SdtVisita_Visdata ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdata = value;
            SetDirty("Visdata");
         }

      }

      [  SoapElement( ElementName = "VisHora" )]
      [  XmlElement( ElementName = "VisHora"  , IsNullable=true )]
      public string gxTpr_Vishora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vishora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vishora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vishora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vishora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vishora
      {
         get {
            return gxTv_SdtVisita_Vishora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vishora = value;
            SetDirty("Vishora");
         }

      }

      [  SoapElement( ElementName = "VisDataHora" )]
      [  XmlElement( ElementName = "VisDataHora"  , IsNullable=true )]
      public string gxTpr_Visdatahora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdatahora).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdatahora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdatahora
      {
         get {
            return gxTv_SdtVisita_Visdatahora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatahora = value;
            SetDirty("Visdatahora");
         }

      }

      [  SoapElement( ElementName = "VisDataFim" )]
      [  XmlElement( ElementName = "VisDataFim"  , IsNullable=true )]
      public string gxTpr_Visdatafim_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdatafim == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visdatafim).value ;
         }

         set {
            gxTv_SdtVisita_Visdatafim_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visdatafim = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdatafim = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdatafim
      {
         get {
            return gxTv_SdtVisita_Visdatafim ;
         }

         set {
            gxTv_SdtVisita_Visdatafim_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatafim = value;
            SetDirty("Visdatafim");
         }

      }

      public void gxTv_SdtVisita_Visdatafim_SetNull( )
      {
         gxTv_SdtVisita_Visdatafim_N = 1;
         gxTv_SdtVisita_Visdatafim = (DateTime)(DateTime.MinValue);
         SetDirty("Visdatafim");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdatafim_IsNull( )
      {
         return (gxTv_SdtVisita_Visdatafim_N==1) ;
      }

      [  SoapElement( ElementName = "VisHoraFim" )]
      [  XmlElement( ElementName = "VisHoraFim"  , IsNullable=true )]
      public string gxTpr_Vishorafim_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vishorafim == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vishorafim).value ;
         }

         set {
            gxTv_SdtVisita_Vishorafim_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vishorafim = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vishorafim = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vishorafim
      {
         get {
            return gxTv_SdtVisita_Vishorafim ;
         }

         set {
            gxTv_SdtVisita_Vishorafim_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Vishorafim = value;
            SetDirty("Vishorafim");
         }

      }

      public void gxTv_SdtVisita_Vishorafim_SetNull( )
      {
         gxTv_SdtVisita_Vishorafim_N = 1;
         gxTv_SdtVisita_Vishorafim = (DateTime)(DateTime.MinValue);
         SetDirty("Vishorafim");
         return  ;
      }

      public bool gxTv_SdtVisita_Vishorafim_IsNull( )
      {
         return (gxTv_SdtVisita_Vishorafim_N==1) ;
      }

      [  SoapElement( ElementName = "VisDataHoraFim" )]
      [  XmlElement( ElementName = "VisDataHoraFim"  , IsNullable=true )]
      public string gxTpr_Visdatahorafim_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdatahorafim == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdatahorafim).value ;
         }

         set {
            gxTv_SdtVisita_Visdatahorafim_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdatahorafim = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdatahorafim = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdatahorafim
      {
         get {
            return gxTv_SdtVisita_Visdatahorafim ;
         }

         set {
            gxTv_SdtVisita_Visdatahorafim_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatahorafim = value;
            SetDirty("Visdatahorafim");
         }

      }

      public void gxTv_SdtVisita_Visdatahorafim_SetNull( )
      {
         gxTv_SdtVisita_Visdatahorafim_N = 1;
         gxTv_SdtVisita_Visdatahorafim = (DateTime)(DateTime.MinValue);
         SetDirty("Visdatahorafim");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdatahorafim_IsNull( )
      {
         return (gxTv_SdtVisita_Visdatahorafim_N==1) ;
      }

      [  SoapElement( ElementName = "VisTipoID" )]
      [  XmlElement( ElementName = "VisTipoID"   )]
      public int gxTpr_Vistipoid
      {
         get {
            return gxTv_SdtVisita_Vistipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistipoid = value;
            SetDirty("Vistipoid");
         }

      }

      [  SoapElement( ElementName = "VisTipoSigla" )]
      [  XmlElement( ElementName = "VisTipoSigla"   )]
      public string gxTpr_Vistiposigla
      {
         get {
            return gxTv_SdtVisita_Vistiposigla ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistiposigla = value;
            SetDirty("Vistiposigla");
         }

      }

      [  SoapElement( ElementName = "VisTipoNome" )]
      [  XmlElement( ElementName = "VisTipoNome"   )]
      public string gxTpr_Vistiponome
      {
         get {
            return gxTv_SdtVisita_Vistiponome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistiponome = value;
            SetDirty("Vistiponome");
         }

      }

      [  SoapElement( ElementName = "VisNegID" )]
      [  XmlElement( ElementName = "VisNegID"   )]
      public Guid gxTpr_Visnegid
      {
         get {
            return gxTv_SdtVisita_Visnegid ;
         }

         set {
            gxTv_SdtVisita_Visnegid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegid = value;
            SetDirty("Visnegid");
         }

      }

      public void gxTv_SdtVisita_Visnegid_SetNull( )
      {
         gxTv_SdtVisita_Visnegid_N = 1;
         gxTv_SdtVisita_Visnegid = Guid.Empty;
         SetDirty("Visnegid");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegid_IsNull( )
      {
         return (gxTv_SdtVisita_Visnegid_N==1) ;
      }

      [  SoapElement( ElementName = "VisNegCodigo" )]
      [  XmlElement( ElementName = "VisNegCodigo"   )]
      public long gxTpr_Visnegcodigo
      {
         get {
            return gxTv_SdtVisita_Visnegcodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcodigo = value;
            SetDirty("Visnegcodigo");
         }

      }

      [  SoapElement( ElementName = "VisNegAssunto" )]
      [  XmlElement( ElementName = "VisNegAssunto"   )]
      public string gxTpr_Visnegassunto
      {
         get {
            return gxTv_SdtVisita_Visnegassunto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegassunto = value;
            SetDirty("Visnegassunto");
         }

      }

      [  SoapElement( ElementName = "VisNegValor" )]
      [  XmlElement( ElementName = "VisNegValor"   )]
      public decimal gxTpr_Visnegvalor
      {
         get {
            return gxTv_SdtVisita_Visnegvalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegvalor = value;
            SetDirty("Visnegvalor");
         }

      }

      [  SoapElement( ElementName = "VisNegCliID" )]
      [  XmlElement( ElementName = "VisNegCliID"   )]
      public Guid gxTpr_Visnegcliid
      {
         get {
            return gxTv_SdtVisita_Visnegcliid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcliid = value;
            SetDirty("Visnegcliid");
         }

      }

      [  SoapElement( ElementName = "VisNegCliNomeFamiliar" )]
      [  XmlElement( ElementName = "VisNegCliNomeFamiliar"   )]
      public string gxTpr_Visnegclinomefamiliar
      {
         get {
            return gxTv_SdtVisita_Visnegclinomefamiliar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegclinomefamiliar = value;
            SetDirty("Visnegclinomefamiliar");
         }

      }

      [  SoapElement( ElementName = "VisNegCpjID" )]
      [  XmlElement( ElementName = "VisNegCpjID"   )]
      public Guid gxTpr_Visnegcpjid
      {
         get {
            return gxTv_SdtVisita_Visnegcpjid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjid = value;
            SetDirty("Visnegcpjid");
         }

      }

      [  SoapElement( ElementName = "VisNegCpjNomFan" )]
      [  XmlElement( ElementName = "VisNegCpjNomFan"   )]
      public string gxTpr_Visnegcpjnomfan
      {
         get {
            return gxTv_SdtVisita_Visnegcpjnomfan ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjnomfan = value;
            SetDirty("Visnegcpjnomfan");
         }

      }

      [  SoapElement( ElementName = "VisNegCpjRazSocial" )]
      [  XmlElement( ElementName = "VisNegCpjRazSocial"   )]
      public string gxTpr_Visnegcpjrazsocial
      {
         get {
            return gxTv_SdtVisita_Visnegcpjrazsocial ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjrazsocial = value;
            SetDirty("Visnegcpjrazsocial");
         }

      }

      [  SoapElement( ElementName = "VisNgfSeq" )]
      [  XmlElement( ElementName = "VisNgfSeq"   )]
      public int gxTpr_Visngfseq
      {
         get {
            return gxTv_SdtVisita_Visngfseq ;
         }

         set {
            gxTv_SdtVisita_Visngfseq_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfseq = value;
            SetDirty("Visngfseq");
         }

      }

      public void gxTv_SdtVisita_Visngfseq_SetNull( )
      {
         gxTv_SdtVisita_Visngfseq_N = 1;
         gxTv_SdtVisita_Visngfseq = 0;
         SetDirty("Visngfseq");
         return  ;
      }

      public bool gxTv_SdtVisita_Visngfseq_IsNull( )
      {
         return (gxTv_SdtVisita_Visngfseq_N==1) ;
      }

      [  SoapElement( ElementName = "VisNgfIteID" )]
      [  XmlElement( ElementName = "VisNgfIteID"   )]
      public Guid gxTpr_Visngfiteid
      {
         get {
            return gxTv_SdtVisita_Visngfiteid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfiteid = value;
            SetDirty("Visngfiteid");
         }

      }

      [  SoapElement( ElementName = "VisNgfIteNome" )]
      [  XmlElement( ElementName = "VisNgfIteNome"   )]
      public string gxTpr_Visngfitenome
      {
         get {
            return gxTv_SdtVisita_Visngfitenome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfitenome = value;
            SetDirty("Visngfitenome");
         }

      }

      [  SoapElement( ElementName = "VisAssunto" )]
      [  XmlElement( ElementName = "VisAssunto"   )]
      public string gxTpr_Visassunto
      {
         get {
            return gxTv_SdtVisita_Visassunto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visassunto = value;
            SetDirty("Visassunto");
         }

      }

      [  SoapElement( ElementName = "VisDescricao" )]
      [  XmlElement( ElementName = "VisDescricao"   )]
      public string gxTpr_Visdescricao
      {
         get {
            return gxTv_SdtVisita_Visdescricao ;
         }

         set {
            gxTv_SdtVisita_Visdescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdescricao = value;
            SetDirty("Visdescricao");
         }

      }

      public void gxTv_SdtVisita_Visdescricao_SetNull( )
      {
         gxTv_SdtVisita_Visdescricao_N = 1;
         gxTv_SdtVisita_Visdescricao = "";
         SetDirty("Visdescricao");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdescricao_IsNull( )
      {
         return (gxTv_SdtVisita_Visdescricao_N==1) ;
      }

      [  SoapElement( ElementName = "VisLink" )]
      [  XmlElement( ElementName = "VisLink"   )]
      public string gxTpr_Vislink
      {
         get {
            return gxTv_SdtVisita_Vislink ;
         }

         set {
            gxTv_SdtVisita_Vislink_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Vislink = value;
            SetDirty("Vislink");
         }

      }

      public void gxTv_SdtVisita_Vislink_SetNull( )
      {
         gxTv_SdtVisita_Vislink_N = 1;
         gxTv_SdtVisita_Vislink = "";
         SetDirty("Vislink");
         return  ;
      }

      public bool gxTv_SdtVisita_Vislink_IsNull( )
      {
         return (gxTv_SdtVisita_Vislink_N==1) ;
      }

      [  SoapElement( ElementName = "VisSituacao" )]
      [  XmlElement( ElementName = "VisSituacao"   )]
      public string gxTpr_Vissituacao
      {
         get {
            return gxTv_SdtVisita_Vissituacao ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vissituacao = value;
            SetDirty("Vissituacao");
         }

      }

      [  SoapElement( ElementName = "VisDel" )]
      [  XmlElement( ElementName = "VisDel"   )]
      public bool gxTpr_Visdel
      {
         get {
            return gxTv_SdtVisita_Visdel ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdel = value;
            SetDirty("Visdel");
         }

      }

      [  SoapElement( ElementName = "VisDelDataHora" )]
      [  XmlElement( ElementName = "VisDelDataHora"  , IsNullable=true )]
      public string gxTpr_Visdeldatahora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdeldatahora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdeldatahora, null, true).value ;
         }

         set {
            gxTv_SdtVisita_Visdeldatahora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdeldatahora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdeldatahora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdeldatahora
      {
         get {
            return gxTv_SdtVisita_Visdeldatahora ;
         }

         set {
            gxTv_SdtVisita_Visdeldatahora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldatahora = value;
            SetDirty("Visdeldatahora");
         }

      }

      public void gxTv_SdtVisita_Visdeldatahora_SetNull( )
      {
         gxTv_SdtVisita_Visdeldatahora_N = 1;
         gxTv_SdtVisita_Visdeldatahora = (DateTime)(DateTime.MinValue);
         SetDirty("Visdeldatahora");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdeldatahora_IsNull( )
      {
         return (gxTv_SdtVisita_Visdeldatahora_N==1) ;
      }

      [  SoapElement( ElementName = "VisDelData" )]
      [  XmlElement( ElementName = "VisDelData"  , IsNullable=true )]
      public string gxTpr_Visdeldata_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdeldata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdeldata).value ;
         }

         set {
            gxTv_SdtVisita_Visdeldata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdeldata = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdeldata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdeldata
      {
         get {
            return gxTv_SdtVisita_Visdeldata ;
         }

         set {
            gxTv_SdtVisita_Visdeldata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldata = value;
            SetDirty("Visdeldata");
         }

      }

      public void gxTv_SdtVisita_Visdeldata_SetNull( )
      {
         gxTv_SdtVisita_Visdeldata_N = 1;
         gxTv_SdtVisita_Visdeldata = (DateTime)(DateTime.MinValue);
         SetDirty("Visdeldata");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdeldata_IsNull( )
      {
         return (gxTv_SdtVisita_Visdeldata_N==1) ;
      }

      [  SoapElement( ElementName = "VisDelHora" )]
      [  XmlElement( ElementName = "VisDelHora"  , IsNullable=true )]
      public string gxTpr_Visdelhora_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdelhora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdelhora).value ;
         }

         set {
            gxTv_SdtVisita_Visdelhora_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdelhora = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdelhora = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdelhora
      {
         get {
            return gxTv_SdtVisita_Visdelhora ;
         }

         set {
            gxTv_SdtVisita_Visdelhora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelhora = value;
            SetDirty("Visdelhora");
         }

      }

      public void gxTv_SdtVisita_Visdelhora_SetNull( )
      {
         gxTv_SdtVisita_Visdelhora_N = 1;
         gxTv_SdtVisita_Visdelhora = (DateTime)(DateTime.MinValue);
         SetDirty("Visdelhora");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelhora_IsNull( )
      {
         return (gxTv_SdtVisita_Visdelhora_N==1) ;
      }

      [  SoapElement( ElementName = "VisDelUsuID" )]
      [  XmlElement( ElementName = "VisDelUsuID"   )]
      public string gxTpr_Visdelusuid
      {
         get {
            return gxTv_SdtVisita_Visdelusuid ;
         }

         set {
            gxTv_SdtVisita_Visdelusuid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusuid = value;
            SetDirty("Visdelusuid");
         }

      }

      public void gxTv_SdtVisita_Visdelusuid_SetNull( )
      {
         gxTv_SdtVisita_Visdelusuid_N = 1;
         gxTv_SdtVisita_Visdelusuid = "";
         SetDirty("Visdelusuid");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelusuid_IsNull( )
      {
         return (gxTv_SdtVisita_Visdelusuid_N==1) ;
      }

      [  SoapElement( ElementName = "VisDelUsuNome" )]
      [  XmlElement( ElementName = "VisDelUsuNome"   )]
      public string gxTpr_Visdelusunome
      {
         get {
            return gxTv_SdtVisita_Visdelusunome ;
         }

         set {
            gxTv_SdtVisita_Visdelusunome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusunome = value;
            SetDirty("Visdelusunome");
         }

      }

      public void gxTv_SdtVisita_Visdelusunome_SetNull( )
      {
         gxTv_SdtVisita_Visdelusunome_N = 1;
         gxTv_SdtVisita_Visdelusunome = "";
         SetDirty("Visdelusunome");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelusunome_IsNull( )
      {
         return (gxTv_SdtVisita_Visdelusunome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtVisita_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtVisita_Mode_SetNull( )
      {
         gxTv_SdtVisita_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtVisita_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtVisita_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtVisita_Initialized_SetNull( )
      {
         gxTv_SdtVisita_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtVisita_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisID_Z" )]
      [  XmlElement( ElementName = "VisID_Z"   )]
      public Guid gxTpr_Visid_Z
      {
         get {
            return gxTv_SdtVisita_Visid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visid_Z = value;
            SetDirty("Visid_Z");
         }

      }

      public void gxTv_SdtVisita_Visid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visid_Z = Guid.Empty;
         SetDirty("Visid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisPaiID_Z" )]
      [  XmlElement( ElementName = "VisPaiID_Z"   )]
      public Guid gxTpr_Vispaiid_Z
      {
         get {
            return gxTv_SdtVisita_Vispaiid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaiid_Z = value;
            SetDirty("Vispaiid_Z");
         }

      }

      public void gxTv_SdtVisita_Vispaiid_Z_SetNull( )
      {
         gxTv_SdtVisita_Vispaiid_Z = Guid.Empty;
         SetDirty("Vispaiid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vispaiid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisPaiData_Z" )]
      [  XmlElement( ElementName = "VisPaiData_Z"  , IsNullable=true )]
      public string gxTpr_Vispaidata_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vispaidata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Vispaidata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Vispaidata_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vispaidata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vispaidata_Z
      {
         get {
            return gxTv_SdtVisita_Vispaidata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaidata_Z = value;
            SetDirty("Vispaidata_Z");
         }

      }

      public void gxTv_SdtVisita_Vispaidata_Z_SetNull( )
      {
         gxTv_SdtVisita_Vispaidata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vispaidata_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vispaidata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisPaiHora_Z" )]
      [  XmlElement( ElementName = "VisPaiHora_Z"  , IsNullable=true )]
      public string gxTpr_Vispaihora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vispaihora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vispaihora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vispaihora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vispaihora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vispaihora_Z
      {
         get {
            return gxTv_SdtVisita_Vispaihora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaihora_Z = value;
            SetDirty("Vispaihora_Z");
         }

      }

      public void gxTv_SdtVisita_Vispaihora_Z_SetNull( )
      {
         gxTv_SdtVisita_Vispaihora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vispaihora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vispaihora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisPaiDataHora_Z" )]
      [  XmlElement( ElementName = "VisPaiDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Vispaidatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vispaidatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vispaidatahora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vispaidatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vispaidatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vispaidatahora_Z
      {
         get {
            return gxTv_SdtVisita_Vispaidatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaidatahora_Z = value;
            SetDirty("Vispaidatahora_Z");
         }

      }

      public void gxTv_SdtVisita_Vispaidatahora_Z_SetNull( )
      {
         gxTv_SdtVisita_Vispaidatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vispaidatahora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vispaidatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisPaiAssunto_Z" )]
      [  XmlElement( ElementName = "VisPaiAssunto_Z"   )]
      public string gxTpr_Vispaiassunto_Z
      {
         get {
            return gxTv_SdtVisita_Vispaiassunto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaiassunto_Z = value;
            SetDirty("Vispaiassunto_Z");
         }

      }

      public void gxTv_SdtVisita_Vispaiassunto_Z_SetNull( )
      {
         gxTv_SdtVisita_Vispaiassunto_Z = "";
         SetDirty("Vispaiassunto_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vispaiassunto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisInsData_Z" )]
      [  XmlElement( ElementName = "VisInsData_Z"  , IsNullable=true )]
      public string gxTpr_Visinsdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visinsdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visinsdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visinsdata_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visinsdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visinsdata_Z
      {
         get {
            return gxTv_SdtVisita_Visinsdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsdata_Z = value;
            SetDirty("Visinsdata_Z");
         }

      }

      public void gxTv_SdtVisita_Visinsdata_Z_SetNull( )
      {
         gxTv_SdtVisita_Visinsdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visinsdata_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisInsHora_Z" )]
      [  XmlElement( ElementName = "VisInsHora_Z"  , IsNullable=true )]
      public string gxTpr_Visinshora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visinshora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visinshora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visinshora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visinshora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visinshora_Z
      {
         get {
            return gxTv_SdtVisita_Visinshora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinshora_Z = value;
            SetDirty("Visinshora_Z");
         }

      }

      public void gxTv_SdtVisita_Visinshora_Z_SetNull( )
      {
         gxTv_SdtVisita_Visinshora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visinshora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinshora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisInsDataHora_Z" )]
      [  XmlElement( ElementName = "VisInsDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Visinsdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visinsdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visinsdatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visinsdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visinsdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visinsdatahora_Z
      {
         get {
            return gxTv_SdtVisita_Visinsdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsdatahora_Z = value;
            SetDirty("Visinsdatahora_Z");
         }

      }

      public void gxTv_SdtVisita_Visinsdatahora_Z_SetNull( )
      {
         gxTv_SdtVisita_Visinsdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visinsdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisInsUsuID_Z" )]
      [  XmlElement( ElementName = "VisInsUsuID_Z"   )]
      public string gxTpr_Visinsusuid_Z
      {
         get {
            return gxTv_SdtVisita_Visinsusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusuid_Z = value;
            SetDirty("Visinsusuid_Z");
         }

      }

      public void gxTv_SdtVisita_Visinsusuid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visinsusuid_Z = "";
         SetDirty("Visinsusuid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisInsUsuNome_Z" )]
      [  XmlElement( ElementName = "VisInsUsuNome_Z"   )]
      public string gxTpr_Visinsusunome_Z
      {
         get {
            return gxTv_SdtVisita_Visinsusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusunome_Z = value;
            SetDirty("Visinsusunome_Z");
         }

      }

      public void gxTv_SdtVisita_Visinsusunome_Z_SetNull( )
      {
         gxTv_SdtVisita_Visinsusunome_Z = "";
         SetDirty("Visinsusunome_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdData_Z" )]
      [  XmlElement( ElementName = "VisUpdData_Z"  , IsNullable=true )]
      public string gxTpr_Visupddata_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visupddata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visupddata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visupddata_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visupddata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visupddata_Z
      {
         get {
            return gxTv_SdtVisita_Visupddata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddata_Z = value;
            SetDirty("Visupddata_Z");
         }

      }

      public void gxTv_SdtVisita_Visupddata_Z_SetNull( )
      {
         gxTv_SdtVisita_Visupddata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visupddata_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupddata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdHora_Z" )]
      [  XmlElement( ElementName = "VisUpdHora_Z"  , IsNullable=true )]
      public string gxTpr_Visupdhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visupdhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visupdhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visupdhora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visupdhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visupdhora_Z
      {
         get {
            return gxTv_SdtVisita_Visupdhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdhora_Z = value;
            SetDirty("Visupdhora_Z");
         }

      }

      public void gxTv_SdtVisita_Visupdhora_Z_SetNull( )
      {
         gxTv_SdtVisita_Visupdhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visupdhora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdDataHora_Z" )]
      [  XmlElement( ElementName = "VisUpdDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Visupddatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visupddatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visupddatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visupddatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visupddatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visupddatahora_Z
      {
         get {
            return gxTv_SdtVisita_Visupddatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddatahora_Z = value;
            SetDirty("Visupddatahora_Z");
         }

      }

      public void gxTv_SdtVisita_Visupddatahora_Z_SetNull( )
      {
         gxTv_SdtVisita_Visupddatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visupddatahora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupddatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdUsuID_Z" )]
      [  XmlElement( ElementName = "VisUpdUsuID_Z"   )]
      public string gxTpr_Visupdusuid_Z
      {
         get {
            return gxTv_SdtVisita_Visupdusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusuid_Z = value;
            SetDirty("Visupdusuid_Z");
         }

      }

      public void gxTv_SdtVisita_Visupdusuid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visupdusuid_Z = "";
         SetDirty("Visupdusuid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdUsuNome_Z" )]
      [  XmlElement( ElementName = "VisUpdUsuNome_Z"   )]
      public string gxTpr_Visupdusunome_Z
      {
         get {
            return gxTv_SdtVisita_Visupdusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusunome_Z = value;
            SetDirty("Visupdusunome_Z");
         }

      }

      public void gxTv_SdtVisita_Visupdusunome_Z_SetNull( )
      {
         gxTv_SdtVisita_Visupdusunome_Z = "";
         SetDirty("Visupdusunome_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisData_Z" )]
      [  XmlElement( ElementName = "VisData_Z"  , IsNullable=true )]
      public string gxTpr_Visdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visdata_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdata_Z
      {
         get {
            return gxTv_SdtVisita_Visdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdata_Z = value;
            SetDirty("Visdata_Z");
         }

      }

      public void gxTv_SdtVisita_Visdata_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visdata_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisHora_Z" )]
      [  XmlElement( ElementName = "VisHora_Z"  , IsNullable=true )]
      public string gxTpr_Vishora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vishora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vishora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vishora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vishora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vishora_Z
      {
         get {
            return gxTv_SdtVisita_Vishora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vishora_Z = value;
            SetDirty("Vishora_Z");
         }

      }

      public void gxTv_SdtVisita_Vishora_Z_SetNull( )
      {
         gxTv_SdtVisita_Vishora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vishora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vishora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDataHora_Z" )]
      [  XmlElement( ElementName = "VisDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Visdatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdatahora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdatahora_Z
      {
         get {
            return gxTv_SdtVisita_Visdatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatahora_Z = value;
            SetDirty("Visdatahora_Z");
         }

      }

      public void gxTv_SdtVisita_Visdatahora_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visdatahora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDataFim_Z" )]
      [  XmlElement( ElementName = "VisDataFim_Z"  , IsNullable=true )]
      public string gxTpr_Visdatafim_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdatafim_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtVisita_Visdatafim_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtVisita_Visdatafim_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdatafim_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdatafim_Z
      {
         get {
            return gxTv_SdtVisita_Visdatafim_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatafim_Z = value;
            SetDirty("Visdatafim_Z");
         }

      }

      public void gxTv_SdtVisita_Visdatafim_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdatafim_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visdatafim_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdatafim_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisHoraFim_Z" )]
      [  XmlElement( ElementName = "VisHoraFim_Z"  , IsNullable=true )]
      public string gxTpr_Vishorafim_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Vishorafim_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Vishorafim_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Vishorafim_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Vishorafim_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Vishorafim_Z
      {
         get {
            return gxTv_SdtVisita_Vishorafim_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vishorafim_Z = value;
            SetDirty("Vishorafim_Z");
         }

      }

      public void gxTv_SdtVisita_Vishorafim_Z_SetNull( )
      {
         gxTv_SdtVisita_Vishorafim_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Vishorafim_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vishorafim_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDataHoraFim_Z" )]
      [  XmlElement( ElementName = "VisDataHoraFim_Z"  , IsNullable=true )]
      public string gxTpr_Visdatahorafim_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdatahorafim_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdatahorafim_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdatahorafim_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdatahorafim_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdatahorafim_Z
      {
         get {
            return gxTv_SdtVisita_Visdatahorafim_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatahorafim_Z = value;
            SetDirty("Visdatahorafim_Z");
         }

      }

      public void gxTv_SdtVisita_Visdatahorafim_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdatahorafim_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visdatahorafim_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdatahorafim_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisTipoID_Z" )]
      [  XmlElement( ElementName = "VisTipoID_Z"   )]
      public int gxTpr_Vistipoid_Z
      {
         get {
            return gxTv_SdtVisita_Vistipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistipoid_Z = value;
            SetDirty("Vistipoid_Z");
         }

      }

      public void gxTv_SdtVisita_Vistipoid_Z_SetNull( )
      {
         gxTv_SdtVisita_Vistipoid_Z = 0;
         SetDirty("Vistipoid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vistipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisTipoSigla_Z" )]
      [  XmlElement( ElementName = "VisTipoSigla_Z"   )]
      public string gxTpr_Vistiposigla_Z
      {
         get {
            return gxTv_SdtVisita_Vistiposigla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistiposigla_Z = value;
            SetDirty("Vistiposigla_Z");
         }

      }

      public void gxTv_SdtVisita_Vistiposigla_Z_SetNull( )
      {
         gxTv_SdtVisita_Vistiposigla_Z = "";
         SetDirty("Vistiposigla_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vistiposigla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisTipoNome_Z" )]
      [  XmlElement( ElementName = "VisTipoNome_Z"   )]
      public string gxTpr_Vistiponome_Z
      {
         get {
            return gxTv_SdtVisita_Vistiponome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vistiponome_Z = value;
            SetDirty("Vistiponome_Z");
         }

      }

      public void gxTv_SdtVisita_Vistiponome_Z_SetNull( )
      {
         gxTv_SdtVisita_Vistiponome_Z = "";
         SetDirty("Vistiponome_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vistiponome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegID_Z" )]
      [  XmlElement( ElementName = "VisNegID_Z"   )]
      public Guid gxTpr_Visnegid_Z
      {
         get {
            return gxTv_SdtVisita_Visnegid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegid_Z = value;
            SetDirty("Visnegid_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegid_Z = Guid.Empty;
         SetDirty("Visnegid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegCodigo_Z" )]
      [  XmlElement( ElementName = "VisNegCodigo_Z"   )]
      public long gxTpr_Visnegcodigo_Z
      {
         get {
            return gxTv_SdtVisita_Visnegcodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcodigo_Z = value;
            SetDirty("Visnegcodigo_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegcodigo_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegcodigo_Z = 0;
         SetDirty("Visnegcodigo_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegcodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegAssunto_Z" )]
      [  XmlElement( ElementName = "VisNegAssunto_Z"   )]
      public string gxTpr_Visnegassunto_Z
      {
         get {
            return gxTv_SdtVisita_Visnegassunto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegassunto_Z = value;
            SetDirty("Visnegassunto_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegassunto_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegassunto_Z = "";
         SetDirty("Visnegassunto_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegassunto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegValor_Z" )]
      [  XmlElement( ElementName = "VisNegValor_Z"   )]
      public decimal gxTpr_Visnegvalor_Z
      {
         get {
            return gxTv_SdtVisita_Visnegvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegvalor_Z = value;
            SetDirty("Visnegvalor_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegvalor_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegvalor_Z = 0;
         SetDirty("Visnegvalor_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegCliID_Z" )]
      [  XmlElement( ElementName = "VisNegCliID_Z"   )]
      public Guid gxTpr_Visnegcliid_Z
      {
         get {
            return gxTv_SdtVisita_Visnegcliid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcliid_Z = value;
            SetDirty("Visnegcliid_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegcliid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegcliid_Z = Guid.Empty;
         SetDirty("Visnegcliid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegcliid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegCliNomeFamiliar_Z" )]
      [  XmlElement( ElementName = "VisNegCliNomeFamiliar_Z"   )]
      public string gxTpr_Visnegclinomefamiliar_Z
      {
         get {
            return gxTv_SdtVisita_Visnegclinomefamiliar_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegclinomefamiliar_Z = value;
            SetDirty("Visnegclinomefamiliar_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegclinomefamiliar_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegclinomefamiliar_Z = "";
         SetDirty("Visnegclinomefamiliar_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegclinomefamiliar_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegCpjID_Z" )]
      [  XmlElement( ElementName = "VisNegCpjID_Z"   )]
      public Guid gxTpr_Visnegcpjid_Z
      {
         get {
            return gxTv_SdtVisita_Visnegcpjid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjid_Z = value;
            SetDirty("Visnegcpjid_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegcpjid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegcpjid_Z = Guid.Empty;
         SetDirty("Visnegcpjid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegcpjid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegCpjNomFan_Z" )]
      [  XmlElement( ElementName = "VisNegCpjNomFan_Z"   )]
      public string gxTpr_Visnegcpjnomfan_Z
      {
         get {
            return gxTv_SdtVisita_Visnegcpjnomfan_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjnomfan_Z = value;
            SetDirty("Visnegcpjnomfan_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegcpjnomfan_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegcpjnomfan_Z = "";
         SetDirty("Visnegcpjnomfan_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegcpjnomfan_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegCpjRazSocial_Z" )]
      [  XmlElement( ElementName = "VisNegCpjRazSocial_Z"   )]
      public string gxTpr_Visnegcpjrazsocial_Z
      {
         get {
            return gxTv_SdtVisita_Visnegcpjrazsocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegcpjrazsocial_Z = value;
            SetDirty("Visnegcpjrazsocial_Z");
         }

      }

      public void gxTv_SdtVisita_Visnegcpjrazsocial_Z_SetNull( )
      {
         gxTv_SdtVisita_Visnegcpjrazsocial_Z = "";
         SetDirty("Visnegcpjrazsocial_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegcpjrazsocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNgfSeq_Z" )]
      [  XmlElement( ElementName = "VisNgfSeq_Z"   )]
      public int gxTpr_Visngfseq_Z
      {
         get {
            return gxTv_SdtVisita_Visngfseq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfseq_Z = value;
            SetDirty("Visngfseq_Z");
         }

      }

      public void gxTv_SdtVisita_Visngfseq_Z_SetNull( )
      {
         gxTv_SdtVisita_Visngfseq_Z = 0;
         SetDirty("Visngfseq_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visngfseq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNgfIteID_Z" )]
      [  XmlElement( ElementName = "VisNgfIteID_Z"   )]
      public Guid gxTpr_Visngfiteid_Z
      {
         get {
            return gxTv_SdtVisita_Visngfiteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfiteid_Z = value;
            SetDirty("Visngfiteid_Z");
         }

      }

      public void gxTv_SdtVisita_Visngfiteid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visngfiteid_Z = Guid.Empty;
         SetDirty("Visngfiteid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visngfiteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNgfIteNome_Z" )]
      [  XmlElement( ElementName = "VisNgfIteNome_Z"   )]
      public string gxTpr_Visngfitenome_Z
      {
         get {
            return gxTv_SdtVisita_Visngfitenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfitenome_Z = value;
            SetDirty("Visngfitenome_Z");
         }

      }

      public void gxTv_SdtVisita_Visngfitenome_Z_SetNull( )
      {
         gxTv_SdtVisita_Visngfitenome_Z = "";
         SetDirty("Visngfitenome_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visngfitenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisAssunto_Z" )]
      [  XmlElement( ElementName = "VisAssunto_Z"   )]
      public string gxTpr_Visassunto_Z
      {
         get {
            return gxTv_SdtVisita_Visassunto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visassunto_Z = value;
            SetDirty("Visassunto_Z");
         }

      }

      public void gxTv_SdtVisita_Visassunto_Z_SetNull( )
      {
         gxTv_SdtVisita_Visassunto_Z = "";
         SetDirty("Visassunto_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visassunto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisLink_Z" )]
      [  XmlElement( ElementName = "VisLink_Z"   )]
      public string gxTpr_Vislink_Z
      {
         get {
            return gxTv_SdtVisita_Vislink_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vislink_Z = value;
            SetDirty("Vislink_Z");
         }

      }

      public void gxTv_SdtVisita_Vislink_Z_SetNull( )
      {
         gxTv_SdtVisita_Vislink_Z = "";
         SetDirty("Vislink_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vislink_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisSituacao_Z" )]
      [  XmlElement( ElementName = "VisSituacao_Z"   )]
      public string gxTpr_Vissituacao_Z
      {
         get {
            return gxTv_SdtVisita_Vissituacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vissituacao_Z = value;
            SetDirty("Vissituacao_Z");
         }

      }

      public void gxTv_SdtVisita_Vissituacao_Z_SetNull( )
      {
         gxTv_SdtVisita_Vissituacao_Z = "";
         SetDirty("Vissituacao_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Vissituacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDel_Z" )]
      [  XmlElement( ElementName = "VisDel_Z"   )]
      public bool gxTpr_Visdel_Z
      {
         get {
            return gxTv_SdtVisita_Visdel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdel_Z = value;
            SetDirty("Visdel_Z");
         }

      }

      public void gxTv_SdtVisita_Visdel_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdel_Z = false;
         SetDirty("Visdel_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelDataHora_Z" )]
      [  XmlElement( ElementName = "VisDelDataHora_Z"  , IsNullable=true )]
      public string gxTpr_Visdeldatahora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdeldatahora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdeldatahora_Z, null, true).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdeldatahora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdeldatahora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdeldatahora_Z
      {
         get {
            return gxTv_SdtVisita_Visdeldatahora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldatahora_Z = value;
            SetDirty("Visdeldatahora_Z");
         }

      }

      public void gxTv_SdtVisita_Visdeldatahora_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdeldatahora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visdeldatahora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdeldatahora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelData_Z" )]
      [  XmlElement( ElementName = "VisDelData_Z"  , IsNullable=true )]
      public string gxTpr_Visdeldata_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdeldata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdeldata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdeldata_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdeldata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdeldata_Z
      {
         get {
            return gxTv_SdtVisita_Visdeldata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldata_Z = value;
            SetDirty("Visdeldata_Z");
         }

      }

      public void gxTv_SdtVisita_Visdeldata_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdeldata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visdeldata_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdeldata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelHora_Z" )]
      [  XmlElement( ElementName = "VisDelHora_Z"  , IsNullable=true )]
      public string gxTpr_Visdelhora_Z_Nullable
      {
         get {
            if ( gxTv_SdtVisita_Visdelhora_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtVisita_Visdelhora_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtVisita_Visdelhora_Z = DateTime.MinValue;
            else
               gxTv_SdtVisita_Visdelhora_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Visdelhora_Z
      {
         get {
            return gxTv_SdtVisita_Visdelhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelhora_Z = value;
            SetDirty("Visdelhora_Z");
         }

      }

      public void gxTv_SdtVisita_Visdelhora_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdelhora_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Visdelhora_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelUsuID_Z" )]
      [  XmlElement( ElementName = "VisDelUsuID_Z"   )]
      public string gxTpr_Visdelusuid_Z
      {
         get {
            return gxTv_SdtVisita_Visdelusuid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusuid_Z = value;
            SetDirty("Visdelusuid_Z");
         }

      }

      public void gxTv_SdtVisita_Visdelusuid_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdelusuid_Z = "";
         SetDirty("Visdelusuid_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelusuid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelUsuNome_Z" )]
      [  XmlElement( ElementName = "VisDelUsuNome_Z"   )]
      public string gxTpr_Visdelusunome_Z
      {
         get {
            return gxTv_SdtVisita_Visdelusunome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusunome_Z = value;
            SetDirty("Visdelusunome_Z");
         }

      }

      public void gxTv_SdtVisita_Visdelusunome_Z_SetNull( )
      {
         gxTv_SdtVisita_Visdelusunome_Z = "";
         SetDirty("Visdelusunome_Z");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelusunome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisPaiID_N" )]
      [  XmlElement( ElementName = "VisPaiID_N"   )]
      public short gxTpr_Vispaiid_N
      {
         get {
            return gxTv_SdtVisita_Vispaiid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vispaiid_N = value;
            SetDirty("Vispaiid_N");
         }

      }

      public void gxTv_SdtVisita_Vispaiid_N_SetNull( )
      {
         gxTv_SdtVisita_Vispaiid_N = 0;
         SetDirty("Vispaiid_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Vispaiid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisInsUsuID_N" )]
      [  XmlElement( ElementName = "VisInsUsuID_N"   )]
      public short gxTpr_Visinsusuid_N
      {
         get {
            return gxTv_SdtVisita_Visinsusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusuid_N = value;
            SetDirty("Visinsusuid_N");
         }

      }

      public void gxTv_SdtVisita_Visinsusuid_N_SetNull( )
      {
         gxTv_SdtVisita_Visinsusuid_N = 0;
         SetDirty("Visinsusuid_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisInsUsuNome_N" )]
      [  XmlElement( ElementName = "VisInsUsuNome_N"   )]
      public short gxTpr_Visinsusunome_N
      {
         get {
            return gxTv_SdtVisita_Visinsusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visinsusunome_N = value;
            SetDirty("Visinsusunome_N");
         }

      }

      public void gxTv_SdtVisita_Visinsusunome_N_SetNull( )
      {
         gxTv_SdtVisita_Visinsusunome_N = 0;
         SetDirty("Visinsusunome_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visinsusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdData_N" )]
      [  XmlElement( ElementName = "VisUpdData_N"   )]
      public short gxTpr_Visupddata_N
      {
         get {
            return gxTv_SdtVisita_Visupddata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddata_N = value;
            SetDirty("Visupddata_N");
         }

      }

      public void gxTv_SdtVisita_Visupddata_N_SetNull( )
      {
         gxTv_SdtVisita_Visupddata_N = 0;
         SetDirty("Visupddata_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupddata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdHora_N" )]
      [  XmlElement( ElementName = "VisUpdHora_N"   )]
      public short gxTpr_Visupdhora_N
      {
         get {
            return gxTv_SdtVisita_Visupdhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdhora_N = value;
            SetDirty("Visupdhora_N");
         }

      }

      public void gxTv_SdtVisita_Visupdhora_N_SetNull( )
      {
         gxTv_SdtVisita_Visupdhora_N = 0;
         SetDirty("Visupdhora_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdDataHora_N" )]
      [  XmlElement( ElementName = "VisUpdDataHora_N"   )]
      public short gxTpr_Visupddatahora_N
      {
         get {
            return gxTv_SdtVisita_Visupddatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupddatahora_N = value;
            SetDirty("Visupddatahora_N");
         }

      }

      public void gxTv_SdtVisita_Visupddatahora_N_SetNull( )
      {
         gxTv_SdtVisita_Visupddatahora_N = 0;
         SetDirty("Visupddatahora_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupddatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdUsuID_N" )]
      [  XmlElement( ElementName = "VisUpdUsuID_N"   )]
      public short gxTpr_Visupdusuid_N
      {
         get {
            return gxTv_SdtVisita_Visupdusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusuid_N = value;
            SetDirty("Visupdusuid_N");
         }

      }

      public void gxTv_SdtVisita_Visupdusuid_N_SetNull( )
      {
         gxTv_SdtVisita_Visupdusuid_N = 0;
         SetDirty("Visupdusuid_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisUpdUsuNome_N" )]
      [  XmlElement( ElementName = "VisUpdUsuNome_N"   )]
      public short gxTpr_Visupdusunome_N
      {
         get {
            return gxTv_SdtVisita_Visupdusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visupdusunome_N = value;
            SetDirty("Visupdusunome_N");
         }

      }

      public void gxTv_SdtVisita_Visupdusunome_N_SetNull( )
      {
         gxTv_SdtVisita_Visupdusunome_N = 0;
         SetDirty("Visupdusunome_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visupdusunome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDataFim_N" )]
      [  XmlElement( ElementName = "VisDataFim_N"   )]
      public short gxTpr_Visdatafim_N
      {
         get {
            return gxTv_SdtVisita_Visdatafim_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatafim_N = value;
            SetDirty("Visdatafim_N");
         }

      }

      public void gxTv_SdtVisita_Visdatafim_N_SetNull( )
      {
         gxTv_SdtVisita_Visdatafim_N = 0;
         SetDirty("Visdatafim_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdatafim_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisHoraFim_N" )]
      [  XmlElement( ElementName = "VisHoraFim_N"   )]
      public short gxTpr_Vishorafim_N
      {
         get {
            return gxTv_SdtVisita_Vishorafim_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vishorafim_N = value;
            SetDirty("Vishorafim_N");
         }

      }

      public void gxTv_SdtVisita_Vishorafim_N_SetNull( )
      {
         gxTv_SdtVisita_Vishorafim_N = 0;
         SetDirty("Vishorafim_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Vishorafim_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDataHoraFim_N" )]
      [  XmlElement( ElementName = "VisDataHoraFim_N"   )]
      public short gxTpr_Visdatahorafim_N
      {
         get {
            return gxTv_SdtVisita_Visdatahorafim_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdatahorafim_N = value;
            SetDirty("Visdatahorafim_N");
         }

      }

      public void gxTv_SdtVisita_Visdatahorafim_N_SetNull( )
      {
         gxTv_SdtVisita_Visdatahorafim_N = 0;
         SetDirty("Visdatahorafim_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdatahorafim_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNegID_N" )]
      [  XmlElement( ElementName = "VisNegID_N"   )]
      public short gxTpr_Visnegid_N
      {
         get {
            return gxTv_SdtVisita_Visnegid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visnegid_N = value;
            SetDirty("Visnegid_N");
         }

      }

      public void gxTv_SdtVisita_Visnegid_N_SetNull( )
      {
         gxTv_SdtVisita_Visnegid_N = 0;
         SetDirty("Visnegid_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visnegid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisNgfSeq_N" )]
      [  XmlElement( ElementName = "VisNgfSeq_N"   )]
      public short gxTpr_Visngfseq_N
      {
         get {
            return gxTv_SdtVisita_Visngfseq_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visngfseq_N = value;
            SetDirty("Visngfseq_N");
         }

      }

      public void gxTv_SdtVisita_Visngfseq_N_SetNull( )
      {
         gxTv_SdtVisita_Visngfseq_N = 0;
         SetDirty("Visngfseq_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visngfseq_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDescricao_N" )]
      [  XmlElement( ElementName = "VisDescricao_N"   )]
      public short gxTpr_Visdescricao_N
      {
         get {
            return gxTv_SdtVisita_Visdescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdescricao_N = value;
            SetDirty("Visdescricao_N");
         }

      }

      public void gxTv_SdtVisita_Visdescricao_N_SetNull( )
      {
         gxTv_SdtVisita_Visdescricao_N = 0;
         SetDirty("Visdescricao_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisLink_N" )]
      [  XmlElement( ElementName = "VisLink_N"   )]
      public short gxTpr_Vislink_N
      {
         get {
            return gxTv_SdtVisita_Vislink_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Vislink_N = value;
            SetDirty("Vislink_N");
         }

      }

      public void gxTv_SdtVisita_Vislink_N_SetNull( )
      {
         gxTv_SdtVisita_Vislink_N = 0;
         SetDirty("Vislink_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Vislink_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelDataHora_N" )]
      [  XmlElement( ElementName = "VisDelDataHora_N"   )]
      public short gxTpr_Visdeldatahora_N
      {
         get {
            return gxTv_SdtVisita_Visdeldatahora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldatahora_N = value;
            SetDirty("Visdeldatahora_N");
         }

      }

      public void gxTv_SdtVisita_Visdeldatahora_N_SetNull( )
      {
         gxTv_SdtVisita_Visdeldatahora_N = 0;
         SetDirty("Visdeldatahora_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdeldatahora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelData_N" )]
      [  XmlElement( ElementName = "VisDelData_N"   )]
      public short gxTpr_Visdeldata_N
      {
         get {
            return gxTv_SdtVisita_Visdeldata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdeldata_N = value;
            SetDirty("Visdeldata_N");
         }

      }

      public void gxTv_SdtVisita_Visdeldata_N_SetNull( )
      {
         gxTv_SdtVisita_Visdeldata_N = 0;
         SetDirty("Visdeldata_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdeldata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelHora_N" )]
      [  XmlElement( ElementName = "VisDelHora_N"   )]
      public short gxTpr_Visdelhora_N
      {
         get {
            return gxTv_SdtVisita_Visdelhora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelhora_N = value;
            SetDirty("Visdelhora_N");
         }

      }

      public void gxTv_SdtVisita_Visdelhora_N_SetNull( )
      {
         gxTv_SdtVisita_Visdelhora_N = 0;
         SetDirty("Visdelhora_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelhora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelUsuID_N" )]
      [  XmlElement( ElementName = "VisDelUsuID_N"   )]
      public short gxTpr_Visdelusuid_N
      {
         get {
            return gxTv_SdtVisita_Visdelusuid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusuid_N = value;
            SetDirty("Visdelusuid_N");
         }

      }

      public void gxTv_SdtVisita_Visdelusuid_N_SetNull( )
      {
         gxTv_SdtVisita_Visdelusuid_N = 0;
         SetDirty("Visdelusuid_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelusuid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VisDelUsuNome_N" )]
      [  XmlElement( ElementName = "VisDelUsuNome_N"   )]
      public short gxTpr_Visdelusunome_N
      {
         get {
            return gxTv_SdtVisita_Visdelusunome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtVisita_Visdelusunome_N = value;
            SetDirty("Visdelusunome_N");
         }

      }

      public void gxTv_SdtVisita_Visdelusunome_N_SetNull( )
      {
         gxTv_SdtVisita_Visdelusunome_N = 0;
         SetDirty("Visdelusunome_N");
         return  ;
      }

      public bool gxTv_SdtVisita_Visdelusunome_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtVisita_Visid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtVisita_Vispaiid = Guid.Empty;
         gxTv_SdtVisita_Vispaidata = DateTime.MinValue;
         gxTv_SdtVisita_Vispaihora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Vispaidatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Vispaiassunto = "";
         gxTv_SdtVisita_Visinsdata = DateTime.MinValue;
         gxTv_SdtVisita_Visinshora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visinsdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visinsusuid = "";
         gxTv_SdtVisita_Visinsusunome = "";
         gxTv_SdtVisita_Visupddata = DateTime.MinValue;
         gxTv_SdtVisita_Visupdhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visupddatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visupdusuid = "";
         gxTv_SdtVisita_Visupdusunome = "";
         gxTv_SdtVisita_Visdata = DateTime.MinValue;
         gxTv_SdtVisita_Vishora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdatafim = DateTime.MinValue;
         gxTv_SdtVisita_Vishorafim = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdatahorafim = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Vistiposigla = "";
         gxTv_SdtVisita_Vistiponome = "";
         gxTv_SdtVisita_Visnegid = Guid.Empty;
         gxTv_SdtVisita_Visnegassunto = "";
         gxTv_SdtVisita_Visnegcliid = Guid.Empty;
         gxTv_SdtVisita_Visnegclinomefamiliar = "";
         gxTv_SdtVisita_Visnegcpjid = Guid.Empty;
         gxTv_SdtVisita_Visnegcpjnomfan = "";
         gxTv_SdtVisita_Visnegcpjrazsocial = "";
         gxTv_SdtVisita_Visngfiteid = Guid.Empty;
         gxTv_SdtVisita_Visngfitenome = "";
         gxTv_SdtVisita_Visassunto = "";
         gxTv_SdtVisita_Visdescricao = "";
         gxTv_SdtVisita_Vislink = "";
         gxTv_SdtVisita_Vissituacao = "PEN";
         gxTv_SdtVisita_Visdeldatahora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdeldata = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdelhora = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdelusuid = "";
         gxTv_SdtVisita_Visdelusunome = "";
         gxTv_SdtVisita_Mode = "";
         gxTv_SdtVisita_Visid_Z = Guid.Empty;
         gxTv_SdtVisita_Vispaiid_Z = Guid.Empty;
         gxTv_SdtVisita_Vispaidata_Z = DateTime.MinValue;
         gxTv_SdtVisita_Vispaihora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Vispaidatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Vispaiassunto_Z = "";
         gxTv_SdtVisita_Visinsdata_Z = DateTime.MinValue;
         gxTv_SdtVisita_Visinshora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visinsdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visinsusuid_Z = "";
         gxTv_SdtVisita_Visinsusunome_Z = "";
         gxTv_SdtVisita_Visupddata_Z = DateTime.MinValue;
         gxTv_SdtVisita_Visupdhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visupddatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visupdusuid_Z = "";
         gxTv_SdtVisita_Visupdusunome_Z = "";
         gxTv_SdtVisita_Visdata_Z = DateTime.MinValue;
         gxTv_SdtVisita_Vishora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdatafim_Z = DateTime.MinValue;
         gxTv_SdtVisita_Vishorafim_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdatahorafim_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Vistiposigla_Z = "";
         gxTv_SdtVisita_Vistiponome_Z = "";
         gxTv_SdtVisita_Visnegid_Z = Guid.Empty;
         gxTv_SdtVisita_Visnegassunto_Z = "";
         gxTv_SdtVisita_Visnegcliid_Z = Guid.Empty;
         gxTv_SdtVisita_Visnegclinomefamiliar_Z = "";
         gxTv_SdtVisita_Visnegcpjid_Z = Guid.Empty;
         gxTv_SdtVisita_Visnegcpjnomfan_Z = "";
         gxTv_SdtVisita_Visnegcpjrazsocial_Z = "";
         gxTv_SdtVisita_Visngfiteid_Z = Guid.Empty;
         gxTv_SdtVisita_Visngfitenome_Z = "";
         gxTv_SdtVisita_Visassunto_Z = "";
         gxTv_SdtVisita_Vislink_Z = "";
         gxTv_SdtVisita_Vissituacao_Z = "";
         gxTv_SdtVisita_Visdeldatahora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdeldata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdelhora_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtVisita_Visdelusuid_Z = "";
         gxTv_SdtVisita_Visdelusunome_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "core.visita", "GeneXus.Programs.core.visita_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtVisita_Initialized ;
      private short gxTv_SdtVisita_Vispaiid_N ;
      private short gxTv_SdtVisita_Visinsusuid_N ;
      private short gxTv_SdtVisita_Visinsusunome_N ;
      private short gxTv_SdtVisita_Visupddata_N ;
      private short gxTv_SdtVisita_Visupdhora_N ;
      private short gxTv_SdtVisita_Visupddatahora_N ;
      private short gxTv_SdtVisita_Visupdusuid_N ;
      private short gxTv_SdtVisita_Visupdusunome_N ;
      private short gxTv_SdtVisita_Visdatafim_N ;
      private short gxTv_SdtVisita_Vishorafim_N ;
      private short gxTv_SdtVisita_Visdatahorafim_N ;
      private short gxTv_SdtVisita_Visnegid_N ;
      private short gxTv_SdtVisita_Visngfseq_N ;
      private short gxTv_SdtVisita_Visdescricao_N ;
      private short gxTv_SdtVisita_Vislink_N ;
      private short gxTv_SdtVisita_Visdeldatahora_N ;
      private short gxTv_SdtVisita_Visdeldata_N ;
      private short gxTv_SdtVisita_Visdelhora_N ;
      private short gxTv_SdtVisita_Visdelusuid_N ;
      private short gxTv_SdtVisita_Visdelusunome_N ;
      private int gxTv_SdtVisita_Vistipoid ;
      private int gxTv_SdtVisita_Visngfseq ;
      private int gxTv_SdtVisita_Vistipoid_Z ;
      private int gxTv_SdtVisita_Visngfseq_Z ;
      private long gxTv_SdtVisita_Visnegcodigo ;
      private long gxTv_SdtVisita_Visnegcodigo_Z ;
      private decimal gxTv_SdtVisita_Visnegvalor ;
      private decimal gxTv_SdtVisita_Visnegvalor_Z ;
      private string gxTv_SdtVisita_Visinsusuid ;
      private string gxTv_SdtVisita_Visupdusuid ;
      private string gxTv_SdtVisita_Visdelusuid ;
      private string gxTv_SdtVisita_Mode ;
      private string gxTv_SdtVisita_Visinsusuid_Z ;
      private string gxTv_SdtVisita_Visupdusuid_Z ;
      private string gxTv_SdtVisita_Visdelusuid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtVisita_Vispaihora ;
      private DateTime gxTv_SdtVisita_Vispaidatahora ;
      private DateTime gxTv_SdtVisita_Visinshora ;
      private DateTime gxTv_SdtVisita_Visinsdatahora ;
      private DateTime gxTv_SdtVisita_Visupdhora ;
      private DateTime gxTv_SdtVisita_Visupddatahora ;
      private DateTime gxTv_SdtVisita_Vishora ;
      private DateTime gxTv_SdtVisita_Visdatahora ;
      private DateTime gxTv_SdtVisita_Vishorafim ;
      private DateTime gxTv_SdtVisita_Visdatahorafim ;
      private DateTime gxTv_SdtVisita_Visdeldatahora ;
      private DateTime gxTv_SdtVisita_Visdeldata ;
      private DateTime gxTv_SdtVisita_Visdelhora ;
      private DateTime gxTv_SdtVisita_Vispaihora_Z ;
      private DateTime gxTv_SdtVisita_Vispaidatahora_Z ;
      private DateTime gxTv_SdtVisita_Visinshora_Z ;
      private DateTime gxTv_SdtVisita_Visinsdatahora_Z ;
      private DateTime gxTv_SdtVisita_Visupdhora_Z ;
      private DateTime gxTv_SdtVisita_Visupddatahora_Z ;
      private DateTime gxTv_SdtVisita_Vishora_Z ;
      private DateTime gxTv_SdtVisita_Visdatahora_Z ;
      private DateTime gxTv_SdtVisita_Vishorafim_Z ;
      private DateTime gxTv_SdtVisita_Visdatahorafim_Z ;
      private DateTime gxTv_SdtVisita_Visdeldatahora_Z ;
      private DateTime gxTv_SdtVisita_Visdeldata_Z ;
      private DateTime gxTv_SdtVisita_Visdelhora_Z ;
      private DateTime datetime_STZ ;
      private DateTime datetimemil_STZ ;
      private DateTime gxTv_SdtVisita_Vispaidata ;
      private DateTime gxTv_SdtVisita_Visinsdata ;
      private DateTime gxTv_SdtVisita_Visupddata ;
      private DateTime gxTv_SdtVisita_Visdata ;
      private DateTime gxTv_SdtVisita_Visdatafim ;
      private DateTime gxTv_SdtVisita_Vispaidata_Z ;
      private DateTime gxTv_SdtVisita_Visinsdata_Z ;
      private DateTime gxTv_SdtVisita_Visupddata_Z ;
      private DateTime gxTv_SdtVisita_Visdata_Z ;
      private DateTime gxTv_SdtVisita_Visdatafim_Z ;
      private bool gxTv_SdtVisita_Visdel ;
      private bool gxTv_SdtVisita_Visdel_Z ;
      private string gxTv_SdtVisita_Visdescricao ;
      private string gxTv_SdtVisita_Vispaiassunto ;
      private string gxTv_SdtVisita_Visinsusunome ;
      private string gxTv_SdtVisita_Visupdusunome ;
      private string gxTv_SdtVisita_Vistiposigla ;
      private string gxTv_SdtVisita_Vistiponome ;
      private string gxTv_SdtVisita_Visnegassunto ;
      private string gxTv_SdtVisita_Visnegclinomefamiliar ;
      private string gxTv_SdtVisita_Visnegcpjnomfan ;
      private string gxTv_SdtVisita_Visnegcpjrazsocial ;
      private string gxTv_SdtVisita_Visngfitenome ;
      private string gxTv_SdtVisita_Visassunto ;
      private string gxTv_SdtVisita_Vislink ;
      private string gxTv_SdtVisita_Vissituacao ;
      private string gxTv_SdtVisita_Visdelusunome ;
      private string gxTv_SdtVisita_Vispaiassunto_Z ;
      private string gxTv_SdtVisita_Visinsusunome_Z ;
      private string gxTv_SdtVisita_Visupdusunome_Z ;
      private string gxTv_SdtVisita_Vistiposigla_Z ;
      private string gxTv_SdtVisita_Vistiponome_Z ;
      private string gxTv_SdtVisita_Visnegassunto_Z ;
      private string gxTv_SdtVisita_Visnegclinomefamiliar_Z ;
      private string gxTv_SdtVisita_Visnegcpjnomfan_Z ;
      private string gxTv_SdtVisita_Visnegcpjrazsocial_Z ;
      private string gxTv_SdtVisita_Visngfitenome_Z ;
      private string gxTv_SdtVisita_Visassunto_Z ;
      private string gxTv_SdtVisita_Vislink_Z ;
      private string gxTv_SdtVisita_Vissituacao_Z ;
      private string gxTv_SdtVisita_Visdelusunome_Z ;
      private Guid gxTv_SdtVisita_Visid ;
      private Guid gxTv_SdtVisita_Vispaiid ;
      private Guid gxTv_SdtVisita_Visnegid ;
      private Guid gxTv_SdtVisita_Visnegcliid ;
      private Guid gxTv_SdtVisita_Visnegcpjid ;
      private Guid gxTv_SdtVisita_Visngfiteid ;
      private Guid gxTv_SdtVisita_Visid_Z ;
      private Guid gxTv_SdtVisita_Vispaiid_Z ;
      private Guid gxTv_SdtVisita_Visnegid_Z ;
      private Guid gxTv_SdtVisita_Visnegcliid_Z ;
      private Guid gxTv_SdtVisita_Visnegcpjid_Z ;
      private Guid gxTv_SdtVisita_Visngfiteid_Z ;
   }

   [DataContract(Name = @"core\Visita", Namespace = "agl_tresorygroup")]
   public class SdtVisita_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtVisita>
   {
      public SdtVisita_RESTInterface( ) : base()
      {
      }

      public SdtVisita_RESTInterface( GeneXus.Programs.core.SdtVisita psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VisID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Visid
      {
         get {
            return sdt.gxTpr_Visid ;
         }

         set {
            sdt.gxTpr_Visid = value;
         }

      }

      [DataMember( Name = "VisPaiID" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Vispaiid
      {
         get {
            return sdt.gxTpr_Vispaiid ;
         }

         set {
            sdt.gxTpr_Vispaiid = value;
         }

      }

      [DataMember( Name = "VisPaiData" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Vispaidata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Vispaidata) ;
         }

         set {
            sdt.gxTpr_Vispaidata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "VisPaiHora" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Vispaihora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Vispaihora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Vispaihora = GXt_dtime1;
         }

      }

      [DataMember( Name = "VisPaiDataHora" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Vispaidatahora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Vispaidatahora) ;
         }

         set {
            sdt.gxTpr_Vispaidatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VisPaiAssunto" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Vispaiassunto
      {
         get {
            return sdt.gxTpr_Vispaiassunto ;
         }

         set {
            sdt.gxTpr_Vispaiassunto = value;
         }

      }

      [DataMember( Name = "VisInsData" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Visinsdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Visinsdata) ;
         }

         set {
            sdt.gxTpr_Visinsdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "VisInsHora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Visinshora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Visinshora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Visinshora = GXt_dtime1;
         }

      }

      [DataMember( Name = "VisInsDataHora" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Visinsdatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Visinsdatahora) ;
         }

         set {
            sdt.gxTpr_Visinsdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VisInsUsuID" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Visinsusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Visinsusuid) ;
         }

         set {
            sdt.gxTpr_Visinsusuid = value;
         }

      }

      [DataMember( Name = "VisInsUsuNome" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Visinsusunome
      {
         get {
            return sdt.gxTpr_Visinsusunome ;
         }

         set {
            sdt.gxTpr_Visinsusunome = value;
         }

      }

      [DataMember( Name = "VisUpdData" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Visupddata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Visupddata) ;
         }

         set {
            sdt.gxTpr_Visupddata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "VisUpdHora" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Visupdhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Visupdhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Visupdhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "VisUpdDataHora" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Visupddatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Visupddatahora) ;
         }

         set {
            sdt.gxTpr_Visupddatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VisUpdUsuID" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Visupdusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Visupdusuid) ;
         }

         set {
            sdt.gxTpr_Visupdusuid = value;
         }

      }

      [DataMember( Name = "VisUpdUsuNome" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Visupdusunome
      {
         get {
            return sdt.gxTpr_Visupdusunome ;
         }

         set {
            sdt.gxTpr_Visupdusunome = value;
         }

      }

      [DataMember( Name = "VisData" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Visdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Visdata) ;
         }

         set {
            sdt.gxTpr_Visdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "VisHora" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Vishora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Vishora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Vishora = GXt_dtime1;
         }

      }

      [DataMember( Name = "VisDataHora" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Visdatahora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Visdatahora) ;
         }

         set {
            sdt.gxTpr_Visdatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VisDataFim" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Visdatafim
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Visdatafim) ;
         }

         set {
            sdt.gxTpr_Visdatafim = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "VisHoraFim" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Vishorafim
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Vishorafim) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Vishorafim = GXt_dtime1;
         }

      }

      [DataMember( Name = "VisDataHoraFim" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Visdatahorafim
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Visdatahorafim) ;
         }

         set {
            sdt.gxTpr_Visdatahorafim = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VisTipoID" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Vistipoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Vistipoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Vistipoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "VisTipoSigla" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Vistiposigla
      {
         get {
            return sdt.gxTpr_Vistiposigla ;
         }

         set {
            sdt.gxTpr_Vistiposigla = value;
         }

      }

      [DataMember( Name = "VisTipoNome" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Vistiponome
      {
         get {
            return sdt.gxTpr_Vistiponome ;
         }

         set {
            sdt.gxTpr_Vistiponome = value;
         }

      }

      [DataMember( Name = "VisNegID" , Order = 25 )]
      [GxSeudo()]
      public Guid gxTpr_Visnegid
      {
         get {
            return sdt.gxTpr_Visnegid ;
         }

         set {
            sdt.gxTpr_Visnegid = value;
         }

      }

      [DataMember( Name = "VisNegCodigo" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Visnegcodigo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Visnegcodigo), 12, 0)) ;
         }

         set {
            sdt.gxTpr_Visnegcodigo = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "VisNegAssunto" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Visnegassunto
      {
         get {
            return sdt.gxTpr_Visnegassunto ;
         }

         set {
            sdt.gxTpr_Visnegassunto = value;
         }

      }

      [DataMember( Name = "VisNegValor" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Visnegvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Visnegvalor, 16, 2)) ;
         }

         set {
            sdt.gxTpr_Visnegvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "VisNegCliID" , Order = 29 )]
      [GxSeudo()]
      public Guid gxTpr_Visnegcliid
      {
         get {
            return sdt.gxTpr_Visnegcliid ;
         }

         set {
            sdt.gxTpr_Visnegcliid = value;
         }

      }

      [DataMember( Name = "VisNegCliNomeFamiliar" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Visnegclinomefamiliar
      {
         get {
            return sdt.gxTpr_Visnegclinomefamiliar ;
         }

         set {
            sdt.gxTpr_Visnegclinomefamiliar = value;
         }

      }

      [DataMember( Name = "VisNegCpjID" , Order = 31 )]
      [GxSeudo()]
      public Guid gxTpr_Visnegcpjid
      {
         get {
            return sdt.gxTpr_Visnegcpjid ;
         }

         set {
            sdt.gxTpr_Visnegcpjid = value;
         }

      }

      [DataMember( Name = "VisNegCpjNomFan" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Visnegcpjnomfan
      {
         get {
            return sdt.gxTpr_Visnegcpjnomfan ;
         }

         set {
            sdt.gxTpr_Visnegcpjnomfan = value;
         }

      }

      [DataMember( Name = "VisNegCpjRazSocial" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Visnegcpjrazsocial
      {
         get {
            return sdt.gxTpr_Visnegcpjrazsocial ;
         }

         set {
            sdt.gxTpr_Visnegcpjrazsocial = value;
         }

      }

      [DataMember( Name = "VisNgfSeq" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Visngfseq
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Visngfseq), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Visngfseq = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "VisNgfIteID" , Order = 35 )]
      [GxSeudo()]
      public Guid gxTpr_Visngfiteid
      {
         get {
            return sdt.gxTpr_Visngfiteid ;
         }

         set {
            sdt.gxTpr_Visngfiteid = value;
         }

      }

      [DataMember( Name = "VisNgfIteNome" , Order = 36 )]
      [GxSeudo()]
      public string gxTpr_Visngfitenome
      {
         get {
            return sdt.gxTpr_Visngfitenome ;
         }

         set {
            sdt.gxTpr_Visngfitenome = value;
         }

      }

      [DataMember( Name = "VisAssunto" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Visassunto
      {
         get {
            return sdt.gxTpr_Visassunto ;
         }

         set {
            sdt.gxTpr_Visassunto = value;
         }

      }

      [DataMember( Name = "VisDescricao" , Order = 38 )]
      public string gxTpr_Visdescricao
      {
         get {
            return sdt.gxTpr_Visdescricao ;
         }

         set {
            sdt.gxTpr_Visdescricao = value;
         }

      }

      [DataMember( Name = "VisLink" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Vislink
      {
         get {
            return sdt.gxTpr_Vislink ;
         }

         set {
            sdt.gxTpr_Vislink = value;
         }

      }

      [DataMember( Name = "VisSituacao" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Vissituacao
      {
         get {
            return sdt.gxTpr_Vissituacao ;
         }

         set {
            sdt.gxTpr_Vissituacao = value;
         }

      }

      [DataMember( Name = "VisDel" , Order = 41 )]
      [GxSeudo()]
      public bool gxTpr_Visdel
      {
         get {
            return sdt.gxTpr_Visdel ;
         }

         set {
            sdt.gxTpr_Visdel = value;
         }

      }

      [DataMember( Name = "VisDelDataHora" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Visdeldatahora
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Visdeldatahora) ;
         }

         set {
            sdt.gxTpr_Visdeldatahora = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VisDelData" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Visdeldata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Visdeldata) ;
         }

         set {
            sdt.gxTpr_Visdeldata = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "VisDelHora" , Order = 44 )]
      [GxSeudo()]
      public string gxTpr_Visdelhora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Visdelhora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Visdelhora = GXt_dtime1;
         }

      }

      [DataMember( Name = "VisDelUsuID" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Visdelusuid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Visdelusuid) ;
         }

         set {
            sdt.gxTpr_Visdelusuid = value;
         }

      }

      [DataMember( Name = "VisDelUsuNome" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Visdelusunome
      {
         get {
            return sdt.gxTpr_Visdelusunome ;
         }

         set {
            sdt.gxTpr_Visdelusunome = value;
         }

      }

      public GeneXus.Programs.core.SdtVisita sdt
      {
         get {
            return (GeneXus.Programs.core.SdtVisita)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtVisita() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 47 )]
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

   [DataContract(Name = @"core\Visita", Namespace = "agl_tresorygroup")]
   public class SdtVisita_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.core.SdtVisita>
   {
      public SdtVisita_RESTLInterface( ) : base()
      {
      }

      public SdtVisita_RESTLInterface( GeneXus.Programs.core.SdtVisita psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "VisAssunto" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Visassunto
      {
         get {
            return sdt.gxTpr_Visassunto ;
         }

         set {
            sdt.gxTpr_Visassunto = value;
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

      public GeneXus.Programs.core.SdtVisita sdt
      {
         get {
            return (GeneXus.Programs.core.SdtVisita)Sdt ;
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
            sdt = new GeneXus.Programs.core.SdtVisita() ;
         }
      }

   }

}
