/*
				   File: type_SdtsdtNegocioPJ
			Description: sdtNegocioPJ
				 Author: Nemo 🐠 for C# (.NET) version 18.0.4.173650
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using GeneXus.Programs;
namespace GeneXus.Programs.core
{
	[XmlRoot(ElementName="sdtNegocioPJ")]
	[XmlType(TypeName="sdtNegocioPJ" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtNegocioPJ : GxUserType
	{
		public SdtsdtNegocioPJ( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtNegocioPJ_Neginshora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_Neginsdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_Neginsusuid = "";

			gxTv_SdtsdtNegocioPJ_Neginsusunome = "";

			gxTv_SdtsdtNegocioPJ_Negclinomefamiliar = "";

			gxTv_SdtsdtNegocioPJ_Negcpjnomfan = "";

			gxTv_SdtsdtNegocioPJ_Negcpjrazsocial = "";

			gxTv_SdtsdtNegocioPJ_Negpjtsigla = "";

			gxTv_SdtsdtNegocioPJ_Negpjtnome = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendnome = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendendereco = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendnumero = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendcomplem = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendbairro = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendcepformat = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendmunnome = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendufsigla = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendufnome = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendcompleto = "";

			gxTv_SdtsdtNegocioPJ_Negagcid = "";

			gxTv_SdtsdtNegocioPJ_Negagcnome = "";

			gxTv_SdtsdtNegocioPJ_Negassunto = "";

			gxTv_SdtsdtNegocioPJ_Negdescricao = "";

			gxTv_SdtsdtNegocioPJ_Negdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_Negdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_Negdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_Negdelusuid = "";

			gxTv_SdtsdtNegocioPJ_Negdelusunome = "";

		}

		public SdtsdtNegocioPJ(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("NegID", gxTpr_Negid, false);


			AddObjectProperty("NegCodigo", gxTpr_Negcodigo, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Neginsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Neginsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Neginsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NegInsData", sDateCnv, false);



			datetime_STZ = gxTpr_Neginshora;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NegInsHora", sDateCnv, false);



			datetime_STZ = gxTpr_Neginsdatahora;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NegInsDataHora", sDateCnv, false);



			AddObjectProperty("NegInsUsuID", gxTpr_Neginsusuid, false);


			AddObjectProperty("NegInsUsuNome", gxTpr_Neginsusunome, false);


			AddObjectProperty("NegCliID", gxTpr_Negcliid, false);


			AddObjectProperty("NegCliMatricula", gxTpr_Negclimatricula, false);


			AddObjectProperty("NegCliNomeFamiliar", gxTpr_Negclinomefamiliar, false);


			AddObjectProperty("NegCpjID", gxTpr_Negcpjid, false);


			AddObjectProperty("NegCpjNomFan", gxTpr_Negcpjnomfan, false);


			AddObjectProperty("NegCpjRazSocial", gxTpr_Negcpjrazsocial, false);


			AddObjectProperty("NegCpjMatricula", gxTpr_Negcpjmatricula, false);


			AddObjectProperty("NegPjtID", gxTpr_Negpjtid, false);


			AddObjectProperty("NegPjtSigla", gxTpr_Negpjtsigla, false);


			AddObjectProperty("NegPjtNome", gxTpr_Negpjtnome, false);


			AddObjectProperty("NegCpjEndSeq", gxTpr_Negcpjendseq, false);


			AddObjectProperty("NegCpjEndNome", gxTpr_Negcpjendnome, false);


			AddObjectProperty("NegCpjEndEndereco", gxTpr_Negcpjendendereco, false);


			AddObjectProperty("NegCpjEndNumero", gxTpr_Negcpjendnumero, false);


			AddObjectProperty("NegCpjEndComplem", gxTpr_Negcpjendcomplem, false);


			AddObjectProperty("NegCpjEndBairro", gxTpr_Negcpjendbairro, false);


			AddObjectProperty("NegCpjEndCep", gxTpr_Negcpjendcep, false);


			AddObjectProperty("NegCpjEndCepFormat", gxTpr_Negcpjendcepformat, false);


			AddObjectProperty("NegCpjEndMunID", gxTpr_Negcpjendmunid, false);


			AddObjectProperty("NegCpjEndMunNome", gxTpr_Negcpjendmunnome, false);


			AddObjectProperty("NegCpjEndUFID", gxTpr_Negcpjendufid, false);


			AddObjectProperty("NegCpjEndUFSigla", gxTpr_Negcpjendufsigla, false);


			AddObjectProperty("NegCpjEndUFNome", gxTpr_Negcpjendufnome, false);


			AddObjectProperty("NegCpjEndCompleto", gxTpr_Negcpjendcompleto, false);


			AddObjectProperty("NegAgcID", gxTpr_Negagcid, false);


			AddObjectProperty("NegAgcNome", gxTpr_Negagcnome, false);


			AddObjectProperty("NegAssunto", gxTpr_Negassunto, false);


			AddObjectProperty("NegDescricao", gxTpr_Negdescricao, false);


			AddObjectProperty("NegPgpTotal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Negpgptotal, 16, 2)), false);


			AddObjectProperty("NegValorEstimado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Negvalorestimado, 16, 2)), false);


			AddObjectProperty("NegValorAtualizado", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Negvaloratualizado, 16, 2)), false);


			AddObjectProperty("NegUltItem", gxTpr_Negultitem, false);


			AddObjectProperty("NegDel", gxTpr_Negdel, false);


			datetime_STZ = gxTpr_Negdeldatahora;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NegDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Negdeldata;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NegDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Negdelhora;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NegDelHora", sDateCnv, false);



			AddObjectProperty("NegDelUsuId", gxTpr_Negdelusuid, false);


			AddObjectProperty("NegDelUsuNome", gxTpr_Negdelusunome, false);

			if (gxTv_SdtsdtNegocioPJ_Item != null)
			{
				AddObjectProperty("Item", gxTv_SdtsdtNegocioPJ_Item, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NegID")]
		[XmlElement(ElementName="NegID")]
		public Guid gxTpr_Negid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negid = value;
				SetDirty("Negid");
			}
		}




		[SoapElement(ElementName="NegCodigo")]
		[XmlElement(ElementName="NegCodigo")]
		public long gxTpr_Negcodigo
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcodigo; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcodigo = value;
				SetDirty("Negcodigo");
			}
		}



		[SoapElement(ElementName="NegInsData")]
		[XmlElement(ElementName="NegInsData" , IsNullable=true)]
		public string gxTpr_Neginsdata_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_Neginsdata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtNegocioPJ_Neginsdata).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginsdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Neginsdata
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Neginsdata; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginsdata = value;
				SetDirty("Neginsdata");
			}
		}


		[SoapElement(ElementName="NegInsHora")]
		[XmlElement(ElementName="NegInsHora" , IsNullable=true)]
		public string gxTpr_Neginshora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_Neginshora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_Neginshora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginshora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Neginshora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Neginshora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginshora = value;
				SetDirty("Neginshora");
			}
		}


		[SoapElement(ElementName="NegInsDataHora")]
		[XmlElement(ElementName="NegInsDataHora" , IsNullable=true)]
		public string gxTpr_Neginsdatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_Neginsdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_Neginsdatahora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginsdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Neginsdatahora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Neginsdatahora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginsdatahora = value;
				SetDirty("Neginsdatahora");
			}
		}



		[SoapElement(ElementName="NegInsUsuID")]
		[XmlElement(ElementName="NegInsUsuID")]
		public string gxTpr_Neginsusuid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Neginsusuid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginsusuid = value;
				SetDirty("Neginsusuid");
			}
		}




		[SoapElement(ElementName="NegInsUsuNome")]
		[XmlElement(ElementName="NegInsUsuNome")]
		public string gxTpr_Neginsusunome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Neginsusunome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Neginsusunome = value;
				SetDirty("Neginsusunome");
			}
		}




		[SoapElement(ElementName="NegCliID")]
		[XmlElement(ElementName="NegCliID")]
		public Guid gxTpr_Negcliid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcliid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcliid = value;
				SetDirty("Negcliid");
			}
		}




		[SoapElement(ElementName="NegCliMatricula")]
		[XmlElement(ElementName="NegCliMatricula")]
		public long gxTpr_Negclimatricula
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negclimatricula; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negclimatricula = value;
				SetDirty("Negclimatricula");
			}
		}




		[SoapElement(ElementName="NegCliNomeFamiliar")]
		[XmlElement(ElementName="NegCliNomeFamiliar")]
		public string gxTpr_Negclinomefamiliar
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negclinomefamiliar; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negclinomefamiliar = value;
				SetDirty("Negclinomefamiliar");
			}
		}




		[SoapElement(ElementName="NegCpjID")]
		[XmlElement(ElementName="NegCpjID")]
		public Guid gxTpr_Negcpjid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjid = value;
				SetDirty("Negcpjid");
			}
		}




		[SoapElement(ElementName="NegCpjNomFan")]
		[XmlElement(ElementName="NegCpjNomFan")]
		public string gxTpr_Negcpjnomfan
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjnomfan; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjnomfan = value;
				SetDirty("Negcpjnomfan");
			}
		}




		[SoapElement(ElementName="NegCpjRazSocial")]
		[XmlElement(ElementName="NegCpjRazSocial")]
		public string gxTpr_Negcpjrazsocial
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjrazsocial; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjrazsocial = value;
				SetDirty("Negcpjrazsocial");
			}
		}




		[SoapElement(ElementName="NegCpjMatricula")]
		[XmlElement(ElementName="NegCpjMatricula")]
		public long gxTpr_Negcpjmatricula
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjmatricula; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjmatricula = value;
				SetDirty("Negcpjmatricula");
			}
		}




		[SoapElement(ElementName="NegPjtID")]
		[XmlElement(ElementName="NegPjtID")]
		public int gxTpr_Negpjtid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negpjtid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negpjtid = value;
				SetDirty("Negpjtid");
			}
		}




		[SoapElement(ElementName="NegPjtSigla")]
		[XmlElement(ElementName="NegPjtSigla")]
		public string gxTpr_Negpjtsigla
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negpjtsigla; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negpjtsigla = value;
				SetDirty("Negpjtsigla");
			}
		}




		[SoapElement(ElementName="NegPjtNome")]
		[XmlElement(ElementName="NegPjtNome")]
		public string gxTpr_Negpjtnome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negpjtnome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negpjtnome = value;
				SetDirty("Negpjtnome");
			}
		}




		[SoapElement(ElementName="NegCpjEndSeq")]
		[XmlElement(ElementName="NegCpjEndSeq")]
		public short gxTpr_Negcpjendseq
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendseq; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendseq = value;
				SetDirty("Negcpjendseq");
			}
		}




		[SoapElement(ElementName="NegCpjEndNome")]
		[XmlElement(ElementName="NegCpjEndNome")]
		public string gxTpr_Negcpjendnome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendnome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendnome = value;
				SetDirty("Negcpjendnome");
			}
		}




		[SoapElement(ElementName="NegCpjEndEndereco")]
		[XmlElement(ElementName="NegCpjEndEndereco")]
		public string gxTpr_Negcpjendendereco
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendendereco; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendendereco = value;
				SetDirty("Negcpjendendereco");
			}
		}




		[SoapElement(ElementName="NegCpjEndNumero")]
		[XmlElement(ElementName="NegCpjEndNumero")]
		public string gxTpr_Negcpjendnumero
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendnumero; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendnumero = value;
				SetDirty("Negcpjendnumero");
			}
		}




		[SoapElement(ElementName="NegCpjEndComplem")]
		[XmlElement(ElementName="NegCpjEndComplem")]
		public string gxTpr_Negcpjendcomplem
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendcomplem; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendcomplem = value;
				SetDirty("Negcpjendcomplem");
			}
		}




		[SoapElement(ElementName="NegCpjEndBairro")]
		[XmlElement(ElementName="NegCpjEndBairro")]
		public string gxTpr_Negcpjendbairro
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendbairro; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendbairro = value;
				SetDirty("Negcpjendbairro");
			}
		}




		[SoapElement(ElementName="NegCpjEndCep")]
		[XmlElement(ElementName="NegCpjEndCep")]
		public int gxTpr_Negcpjendcep
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendcep; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendcep = value;
				SetDirty("Negcpjendcep");
			}
		}




		[SoapElement(ElementName="NegCpjEndCepFormat")]
		[XmlElement(ElementName="NegCpjEndCepFormat")]
		public string gxTpr_Negcpjendcepformat
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendcepformat; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendcepformat = value;
				SetDirty("Negcpjendcepformat");
			}
		}




		[SoapElement(ElementName="NegCpjEndMunID")]
		[XmlElement(ElementName="NegCpjEndMunID")]
		public int gxTpr_Negcpjendmunid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendmunid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendmunid = value;
				SetDirty("Negcpjendmunid");
			}
		}




		[SoapElement(ElementName="NegCpjEndMunNome")]
		[XmlElement(ElementName="NegCpjEndMunNome")]
		public string gxTpr_Negcpjendmunnome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendmunnome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendmunnome = value;
				SetDirty("Negcpjendmunnome");
			}
		}




		[SoapElement(ElementName="NegCpjEndUFID")]
		[XmlElement(ElementName="NegCpjEndUFID")]
		public short gxTpr_Negcpjendufid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendufid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendufid = value;
				SetDirty("Negcpjendufid");
			}
		}




		[SoapElement(ElementName="NegCpjEndUFSigla")]
		[XmlElement(ElementName="NegCpjEndUFSigla")]
		public string gxTpr_Negcpjendufsigla
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendufsigla; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendufsigla = value;
				SetDirty("Negcpjendufsigla");
			}
		}




		[SoapElement(ElementName="NegCpjEndUFNome")]
		[XmlElement(ElementName="NegCpjEndUFNome")]
		public string gxTpr_Negcpjendufnome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendufnome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendufnome = value;
				SetDirty("Negcpjendufnome");
			}
		}




		[SoapElement(ElementName="NegCpjEndCompleto")]
		[XmlElement(ElementName="NegCpjEndCompleto")]
		public string gxTpr_Negcpjendcompleto
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negcpjendcompleto; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negcpjendcompleto = value;
				SetDirty("Negcpjendcompleto");
			}
		}




		[SoapElement(ElementName="NegAgcID")]
		[XmlElement(ElementName="NegAgcID")]
		public string gxTpr_Negagcid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negagcid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negagcid = value;
				SetDirty("Negagcid");
			}
		}




		[SoapElement(ElementName="NegAgcNome")]
		[XmlElement(ElementName="NegAgcNome")]
		public string gxTpr_Negagcnome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negagcnome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negagcnome = value;
				SetDirty("Negagcnome");
			}
		}




		[SoapElement(ElementName="NegAssunto")]
		[XmlElement(ElementName="NegAssunto")]
		public string gxTpr_Negassunto
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negassunto; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negassunto = value;
				SetDirty("Negassunto");
			}
		}




		[SoapElement(ElementName="NegDescricao")]
		[XmlElement(ElementName="NegDescricao")]
		public string gxTpr_Negdescricao
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negdescricao; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdescricao = value;
				SetDirty("Negdescricao");
			}
		}



		[SoapElement(ElementName="NegPgpTotal")]
		[XmlElement(ElementName="NegPgpTotal")]
		public string gxTpr_Negpgptotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtNegocioPJ_Negpgptotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negpgptotal = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Negpgptotal
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negpgptotal; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negpgptotal = value;
				SetDirty("Negpgptotal");
			}
		}



		[SoapElement(ElementName="NegValorEstimado")]
		[XmlElement(ElementName="NegValorEstimado")]
		public string gxTpr_Negvalorestimado_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtNegocioPJ_Negvalorestimado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negvalorestimado = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Negvalorestimado
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negvalorestimado; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negvalorestimado = value;
				SetDirty("Negvalorestimado");
			}
		}



		[SoapElement(ElementName="NegValorAtualizado")]
		[XmlElement(ElementName="NegValorAtualizado")]
		public string gxTpr_Negvaloratualizado_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtNegocioPJ_Negvaloratualizado, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negvaloratualizado = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Negvaloratualizado
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negvaloratualizado; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negvaloratualizado = value;
				SetDirty("Negvaloratualizado");
			}
		}




		[SoapElement(ElementName="NegUltItem")]
		[XmlElement(ElementName="NegUltItem")]
		public int gxTpr_Negultitem
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negultitem; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negultitem = value;
				SetDirty("Negultitem");
			}
		}




		[SoapElement(ElementName="NegDel")]
		[XmlElement(ElementName="NegDel")]
		public bool gxTpr_Negdel
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negdel; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdel = value;
				SetDirty("Negdel");
			}
		}



		[SoapElement(ElementName="NegDelDataHora")]
		[XmlElement(ElementName="NegDelDataHora" , IsNullable=true)]
		public string gxTpr_Negdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_Negdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_Negdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Negdeldatahora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negdeldatahora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdeldatahora = value;
				SetDirty("Negdeldatahora");
			}
		}


		[SoapElement(ElementName="NegDelData")]
		[XmlElement(ElementName="NegDelData" , IsNullable=true)]
		public string gxTpr_Negdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_Negdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_Negdeldata).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Negdeldata
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negdeldata; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdeldata = value;
				SetDirty("Negdeldata");
			}
		}


		[SoapElement(ElementName="NegDelHora")]
		[XmlElement(ElementName="NegDelHora" , IsNullable=true)]
		public string gxTpr_Negdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_Negdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_Negdelhora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Negdelhora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negdelhora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdelhora = value;
				SetDirty("Negdelhora");
			}
		}



		[SoapElement(ElementName="NegDelUsuId")]
		[XmlElement(ElementName="NegDelUsuId")]
		public string gxTpr_Negdelusuid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negdelusuid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdelusuid = value;
				SetDirty("Negdelusuid");
			}
		}




		[SoapElement(ElementName="NegDelUsuNome")]
		[XmlElement(ElementName="NegDelUsuNome")]
		public string gxTpr_Negdelusunome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_Negdelusunome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_Negdelusunome = value;
				SetDirty("Negdelusunome");
			}
		}




		[SoapElement(ElementName="Item" )]
		[XmlArray(ElementName="Item"  )]
		[XmlArrayItemAttribute(ElementName="ItemItem" , IsNullable=false )]
		public GXBaseCollection<SdtsdtNegocioPJ_ItemItem> gxTpr_Item
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_Item == null )
				{
					gxTv_SdtsdtNegocioPJ_Item = new GXBaseCollection<SdtsdtNegocioPJ_ItemItem>( context, "sdtNegocioPJ.ItemItem", "");
				}
				return gxTv_SdtsdtNegocioPJ_Item;
			}
			set {
				gxTv_SdtsdtNegocioPJ_Item_N = false;
				gxTv_SdtsdtNegocioPJ_Item = value;
				SetDirty("Item");
			}
		}

		public void gxTv_SdtsdtNegocioPJ_Item_SetNull()
		{
			gxTv_SdtsdtNegocioPJ_Item_N = true;
			gxTv_SdtsdtNegocioPJ_Item = null;
		}

		public bool gxTv_SdtsdtNegocioPJ_Item_IsNull()
		{
			return gxTv_SdtsdtNegocioPJ_Item == null;
		}
		public bool ShouldSerializegxTpr_Item_GxSimpleCollection_Json()
		{
			return gxTv_SdtsdtNegocioPJ_Item != null && gxTv_SdtsdtNegocioPJ_Item.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtsdtNegocioPJ_Neginshora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_Neginsdatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_Neginsusuid = "";
			gxTv_SdtsdtNegocioPJ_Neginsusunome = "";


			gxTv_SdtsdtNegocioPJ_Negclinomefamiliar = "";

			gxTv_SdtsdtNegocioPJ_Negcpjnomfan = "";
			gxTv_SdtsdtNegocioPJ_Negcpjrazsocial = "";


			gxTv_SdtsdtNegocioPJ_Negpjtsigla = "";
			gxTv_SdtsdtNegocioPJ_Negpjtnome = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendnome = "";
			gxTv_SdtsdtNegocioPJ_Negcpjendendereco = "";
			gxTv_SdtsdtNegocioPJ_Negcpjendnumero = "";
			gxTv_SdtsdtNegocioPJ_Negcpjendcomplem = "";
			gxTv_SdtsdtNegocioPJ_Negcpjendbairro = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendcepformat = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendmunnome = "";

			gxTv_SdtsdtNegocioPJ_Negcpjendufsigla = "";
			gxTv_SdtsdtNegocioPJ_Negcpjendufnome = "";
			gxTv_SdtsdtNegocioPJ_Negcpjendcompleto = "";
			gxTv_SdtsdtNegocioPJ_Negagcid = "";
			gxTv_SdtsdtNegocioPJ_Negagcnome = "";
			gxTv_SdtsdtNegocioPJ_Negassunto = "";
			gxTv_SdtsdtNegocioPJ_Negdescricao = "";





			gxTv_SdtsdtNegocioPJ_Negdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_Negdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_Negdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_Negdelusuid = "";
			gxTv_SdtsdtNegocioPJ_Negdelusunome = "";

			gxTv_SdtsdtNegocioPJ_Item_N = true;

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected Guid gxTv_SdtsdtNegocioPJ_Negid;
		 

		protected long gxTv_SdtsdtNegocioPJ_Negcodigo;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_Neginsdata;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_Neginshora;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_Neginsdatahora;
		 

		protected string gxTv_SdtsdtNegocioPJ_Neginsusuid;
		 

		protected string gxTv_SdtsdtNegocioPJ_Neginsusunome;
		 

		protected Guid gxTv_SdtsdtNegocioPJ_Negcliid;
		 

		protected long gxTv_SdtsdtNegocioPJ_Negclimatricula;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negclinomefamiliar;
		 

		protected Guid gxTv_SdtsdtNegocioPJ_Negcpjid;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjnomfan;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjrazsocial;
		 

		protected long gxTv_SdtsdtNegocioPJ_Negcpjmatricula;
		 

		protected int gxTv_SdtsdtNegocioPJ_Negpjtid;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negpjtsigla;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negpjtnome;
		 

		protected short gxTv_SdtsdtNegocioPJ_Negcpjendseq;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendnome;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendendereco;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendnumero;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendcomplem;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendbairro;
		 

		protected int gxTv_SdtsdtNegocioPJ_Negcpjendcep;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendcepformat;
		 

		protected int gxTv_SdtsdtNegocioPJ_Negcpjendmunid;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendmunnome;
		 

		protected short gxTv_SdtsdtNegocioPJ_Negcpjendufid;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendufsigla;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendufnome;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negcpjendcompleto;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negagcid;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negagcnome;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negassunto;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negdescricao;
		 

		protected decimal gxTv_SdtsdtNegocioPJ_Negpgptotal;
		 

		protected decimal gxTv_SdtsdtNegocioPJ_Negvalorestimado;
		 

		protected decimal gxTv_SdtsdtNegocioPJ_Negvaloratualizado;
		 

		protected int gxTv_SdtsdtNegocioPJ_Negultitem;
		 

		protected bool gxTv_SdtsdtNegocioPJ_Negdel;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_Negdeldatahora;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_Negdeldata;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_Negdelhora;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negdelusuid;
		 

		protected string gxTv_SdtsdtNegocioPJ_Negdelusunome;
		 
		protected bool gxTv_SdtsdtNegocioPJ_Item_N;
		protected GXBaseCollection<SdtsdtNegocioPJ_ItemItem> gxTv_SdtsdtNegocioPJ_Item = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtNegocioPJ", Namespace="agl_tresorygroup")]
	public class SdtsdtNegocioPJ_RESTInterface : GxGenericCollectionItem<SdtsdtNegocioPJ>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtNegocioPJ_RESTInterface( ) : base()
		{	
		}

		public SdtsdtNegocioPJ_RESTInterface( SdtsdtNegocioPJ psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NegID", Order=0)]
		public Guid gxTpr_Negid
		{
			get { 
				return sdt.gxTpr_Negid;

			}
			set { 
				sdt.gxTpr_Negid = value;
			}
		}

		[DataMember(Name="NegCodigo", Order=1)]
		public  string gxTpr_Negcodigo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Negcodigo, 12, 0));

			}
			set { 
				sdt.gxTpr_Negcodigo = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegInsData", Order=2)]
		public  string gxTpr_Neginsdata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Neginsdata);

			}
			set { 
				sdt.gxTpr_Neginsdata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="NegInsHora", Order=3)]
		public  string gxTpr_Neginshora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Neginshora);

			}
			set { 
				sdt.gxTpr_Neginshora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NegInsDataHora", Order=4)]
		public  string gxTpr_Neginsdatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Neginsdatahora);

			}
			set { 
				sdt.gxTpr_Neginsdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NegInsUsuID", Order=5)]
		public  string gxTpr_Neginsusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Neginsusuid);

			}
			set { 
				 sdt.gxTpr_Neginsusuid = value;
			}
		}

		[DataMember(Name="NegInsUsuNome", Order=6)]
		public  string gxTpr_Neginsusunome
		{
			get { 
				return sdt.gxTpr_Neginsusunome;

			}
			set { 
				 sdt.gxTpr_Neginsusunome = value;
			}
		}

		[DataMember(Name="NegCliID", Order=7)]
		public Guid gxTpr_Negcliid
		{
			get { 
				return sdt.gxTpr_Negcliid;

			}
			set { 
				sdt.gxTpr_Negcliid = value;
			}
		}

		[DataMember(Name="NegCliMatricula", Order=8)]
		public  string gxTpr_Negclimatricula
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Negclimatricula, 12, 0));

			}
			set { 
				sdt.gxTpr_Negclimatricula = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegCliNomeFamiliar", Order=9)]
		public  string gxTpr_Negclinomefamiliar
		{
			get { 
				return sdt.gxTpr_Negclinomefamiliar;

			}
			set { 
				 sdt.gxTpr_Negclinomefamiliar = value;
			}
		}

		[DataMember(Name="NegCpjID", Order=10)]
		public Guid gxTpr_Negcpjid
		{
			get { 
				return sdt.gxTpr_Negcpjid;

			}
			set { 
				sdt.gxTpr_Negcpjid = value;
			}
		}

		[DataMember(Name="NegCpjNomFan", Order=11)]
		public  string gxTpr_Negcpjnomfan
		{
			get { 
				return sdt.gxTpr_Negcpjnomfan;

			}
			set { 
				 sdt.gxTpr_Negcpjnomfan = value;
			}
		}

		[DataMember(Name="NegCpjRazSocial", Order=12)]
		public  string gxTpr_Negcpjrazsocial
		{
			get { 
				return sdt.gxTpr_Negcpjrazsocial;

			}
			set { 
				 sdt.gxTpr_Negcpjrazsocial = value;
			}
		}

		[DataMember(Name="NegCpjMatricula", Order=13)]
		public  string gxTpr_Negcpjmatricula
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Negcpjmatricula, 12, 0));

			}
			set { 
				sdt.gxTpr_Negcpjmatricula = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegPjtID", Order=14)]
		public  string gxTpr_Negpjtid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Negpjtid, 9, 0));

			}
			set { 
				sdt.gxTpr_Negpjtid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegPjtSigla", Order=15)]
		public  string gxTpr_Negpjtsigla
		{
			get { 
				return sdt.gxTpr_Negpjtsigla;

			}
			set { 
				 sdt.gxTpr_Negpjtsigla = value;
			}
		}

		[DataMember(Name="NegPjtNome", Order=16)]
		public  string gxTpr_Negpjtnome
		{
			get { 
				return sdt.gxTpr_Negpjtnome;

			}
			set { 
				 sdt.gxTpr_Negpjtnome = value;
			}
		}

		[DataMember(Name="NegCpjEndSeq", Order=17)]
		public short gxTpr_Negcpjendseq
		{
			get { 
				return sdt.gxTpr_Negcpjendseq;

			}
			set { 
				sdt.gxTpr_Negcpjendseq = value;
			}
		}

		[DataMember(Name="NegCpjEndNome", Order=18)]
		public  string gxTpr_Negcpjendnome
		{
			get { 
				return sdt.gxTpr_Negcpjendnome;

			}
			set { 
				 sdt.gxTpr_Negcpjendnome = value;
			}
		}

		[DataMember(Name="NegCpjEndEndereco", Order=19)]
		public  string gxTpr_Negcpjendendereco
		{
			get { 
				return sdt.gxTpr_Negcpjendendereco;

			}
			set { 
				 sdt.gxTpr_Negcpjendendereco = value;
			}
		}

		[DataMember(Name="NegCpjEndNumero", Order=20)]
		public  string gxTpr_Negcpjendnumero
		{
			get { 
				return sdt.gxTpr_Negcpjendnumero;

			}
			set { 
				 sdt.gxTpr_Negcpjendnumero = value;
			}
		}

		[DataMember(Name="NegCpjEndComplem", Order=21)]
		public  string gxTpr_Negcpjendcomplem
		{
			get { 
				return sdt.gxTpr_Negcpjendcomplem;

			}
			set { 
				 sdt.gxTpr_Negcpjendcomplem = value;
			}
		}

		[DataMember(Name="NegCpjEndBairro", Order=22)]
		public  string gxTpr_Negcpjendbairro
		{
			get { 
				return sdt.gxTpr_Negcpjendbairro;

			}
			set { 
				 sdt.gxTpr_Negcpjendbairro = value;
			}
		}

		[DataMember(Name="NegCpjEndCep", Order=23)]
		public  string gxTpr_Negcpjendcep
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Negcpjendcep, 8, 0));

			}
			set { 
				sdt.gxTpr_Negcpjendcep = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegCpjEndCepFormat", Order=24)]
		public  string gxTpr_Negcpjendcepformat
		{
			get { 
				return sdt.gxTpr_Negcpjendcepformat;

			}
			set { 
				 sdt.gxTpr_Negcpjendcepformat = value;
			}
		}

		[DataMember(Name="NegCpjEndMunID", Order=25)]
		public  string gxTpr_Negcpjendmunid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Negcpjendmunid, 7, 0));

			}
			set { 
				sdt.gxTpr_Negcpjendmunid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegCpjEndMunNome", Order=26)]
		public  string gxTpr_Negcpjendmunnome
		{
			get { 
				return sdt.gxTpr_Negcpjendmunnome;

			}
			set { 
				 sdt.gxTpr_Negcpjendmunnome = value;
			}
		}

		[DataMember(Name="NegCpjEndUFID", Order=27)]
		public short gxTpr_Negcpjendufid
		{
			get { 
				return sdt.gxTpr_Negcpjendufid;

			}
			set { 
				sdt.gxTpr_Negcpjendufid = value;
			}
		}

		[DataMember(Name="NegCpjEndUFSigla", Order=28)]
		public  string gxTpr_Negcpjendufsigla
		{
			get { 
				return sdt.gxTpr_Negcpjendufsigla;

			}
			set { 
				 sdt.gxTpr_Negcpjendufsigla = value;
			}
		}

		[DataMember(Name="NegCpjEndUFNome", Order=29)]
		public  string gxTpr_Negcpjendufnome
		{
			get { 
				return sdt.gxTpr_Negcpjendufnome;

			}
			set { 
				 sdt.gxTpr_Negcpjendufnome = value;
			}
		}

		[DataMember(Name="NegCpjEndCompleto", Order=30)]
		public  string gxTpr_Negcpjendcompleto
		{
			get { 
				return sdt.gxTpr_Negcpjendcompleto;

			}
			set { 
				 sdt.gxTpr_Negcpjendcompleto = value;
			}
		}

		[DataMember(Name="NegAgcID", Order=31)]
		public  string gxTpr_Negagcid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Negagcid);

			}
			set { 
				 sdt.gxTpr_Negagcid = value;
			}
		}

		[DataMember(Name="NegAgcNome", Order=32)]
		public  string gxTpr_Negagcnome
		{
			get { 
				return sdt.gxTpr_Negagcnome;

			}
			set { 
				 sdt.gxTpr_Negagcnome = value;
			}
		}

		[DataMember(Name="NegAssunto", Order=33)]
		public  string gxTpr_Negassunto
		{
			get { 
				return sdt.gxTpr_Negassunto;

			}
			set { 
				 sdt.gxTpr_Negassunto = value;
			}
		}

		[DataMember(Name="NegDescricao", Order=34)]
		public  string gxTpr_Negdescricao
		{
			get { 
				return sdt.gxTpr_Negdescricao;

			}
			set { 
				 sdt.gxTpr_Negdescricao = value;
			}
		}

		[DataMember(Name="NegPgpTotal", Order=35)]
		public  string gxTpr_Negpgptotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Negpgptotal, 16, 2));

			}
			set { 
				sdt.gxTpr_Negpgptotal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegValorEstimado", Order=36)]
		public  string gxTpr_Negvalorestimado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Negvalorestimado, 16, 2));

			}
			set { 
				sdt.gxTpr_Negvalorestimado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegValorAtualizado", Order=37)]
		public  string gxTpr_Negvaloratualizado
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Negvaloratualizado, 16, 2));

			}
			set { 
				sdt.gxTpr_Negvaloratualizado =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegUltItem", Order=38)]
		public  string gxTpr_Negultitem
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Negultitem, 8, 0));

			}
			set { 
				sdt.gxTpr_Negultitem = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NegDel", Order=39)]
		public bool gxTpr_Negdel
		{
			get { 
				return sdt.gxTpr_Negdel;

			}
			set { 
				sdt.gxTpr_Negdel = value;
			}
		}

		[DataMember(Name="NegDelDataHora", Order=40)]
		public  string gxTpr_Negdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Negdeldatahora);

			}
			set { 
				sdt.gxTpr_Negdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NegDelData", Order=41)]
		public  string gxTpr_Negdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Negdeldata);

			}
			set { 
				sdt.gxTpr_Negdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NegDelHora", Order=42)]
		public  string gxTpr_Negdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Negdelhora);

			}
			set { 
				sdt.gxTpr_Negdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NegDelUsuId", Order=43)]
		public  string gxTpr_Negdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Negdelusuid);

			}
			set { 
				 sdt.gxTpr_Negdelusuid = value;
			}
		}

		[DataMember(Name="NegDelUsuNome", Order=44)]
		public  string gxTpr_Negdelusunome
		{
			get { 
				return sdt.gxTpr_Negdelusunome;

			}
			set { 
				 sdt.gxTpr_Negdelusunome = value;
			}
		}

		[DataMember(Name="Item", Order=45, EmitDefaultValue=false)]
		public GxGenericCollection<SdtsdtNegocioPJ_ItemItem_RESTInterface> gxTpr_Item
		{
			get {
				if (sdt.ShouldSerializegxTpr_Item_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtsdtNegocioPJ_ItemItem_RESTInterface>(sdt.gxTpr_Item);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Item);
			}
		}


		#endregion

		public SdtsdtNegocioPJ sdt
		{
			get { 
				return (SdtsdtNegocioPJ)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtsdtNegocioPJ() ;
			}
		}
	}
	#endregion
}