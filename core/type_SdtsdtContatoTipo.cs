/*
				   File: type_SdtsdtContatoTipo
			Description: sdtContatoTipo
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
	[XmlRoot(ElementName="sdtContatoTipo")]
	[XmlType(TypeName="sdtContatoTipo" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtContatoTipo : GxUserType
	{
		public SdtsdtContatoTipo( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtContatoTipo_Cotsigla = "";

			gxTv_SdtsdtContatoTipo_Cotnome = "";

			gxTv_SdtsdtContatoTipo_Cotdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtContatoTipo_Cotdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtContatoTipo_Cotdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtContatoTipo_Cotdelusuid = "";

			gxTv_SdtsdtContatoTipo_Cotdelusunome = "";

		}

		public SdtsdtContatoTipo(IGxContext context)
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
			AddObjectProperty("CotID", gxTpr_Cotid, false);


			AddObjectProperty("CotSigla", gxTpr_Cotsigla, false);


			AddObjectProperty("CotNome", gxTpr_Cotnome, false);


			AddObjectProperty("CotAtivo", gxTpr_Cotativo, false);


			AddObjectProperty("CotDel", gxTpr_Cotdel, false);


			datetime_STZ = gxTpr_Cotdeldatahora;
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
			AddObjectProperty("CotDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Cotdeldata;
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
			AddObjectProperty("CotDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Cotdelhora;
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
			AddObjectProperty("CotDelHora", sDateCnv, false);



			AddObjectProperty("CotDelUsuId", gxTpr_Cotdelusuid, false);


			AddObjectProperty("CotDelUsuNome", gxTpr_Cotdelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CotID")]
		[XmlElement(ElementName="CotID")]
		public int gxTpr_Cotid
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotid; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotid = value;
				SetDirty("Cotid");
			}
		}




		[SoapElement(ElementName="CotSigla")]
		[XmlElement(ElementName="CotSigla")]
		public string gxTpr_Cotsigla
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotsigla; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotsigla = value;
				SetDirty("Cotsigla");
			}
		}




		[SoapElement(ElementName="CotNome")]
		[XmlElement(ElementName="CotNome")]
		public string gxTpr_Cotnome
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotnome; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotnome = value;
				SetDirty("Cotnome");
			}
		}




		[SoapElement(ElementName="CotAtivo")]
		[XmlElement(ElementName="CotAtivo")]
		public bool gxTpr_Cotativo
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotativo; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotativo = value;
				SetDirty("Cotativo");
			}
		}




		[SoapElement(ElementName="CotDel")]
		[XmlElement(ElementName="CotDel")]
		public bool gxTpr_Cotdel
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotdel; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdel = value;
				SetDirty("Cotdel");
			}
		}



		[SoapElement(ElementName="CotDelDataHora")]
		[XmlElement(ElementName="CotDelDataHora" , IsNullable=true)]
		public string gxTpr_Cotdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtContatoTipo_Cotdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtContatoTipo_Cotdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Cotdeldatahora
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotdeldatahora; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdeldatahora = value;
				SetDirty("Cotdeldatahora");
			}
		}


		[SoapElement(ElementName="CotDelData")]
		[XmlElement(ElementName="CotDelData" , IsNullable=true)]
		public string gxTpr_Cotdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtContatoTipo_Cotdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtContatoTipo_Cotdeldata).value ;
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Cotdeldata
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotdeldata; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdeldata = value;
				SetDirty("Cotdeldata");
			}
		}


		[SoapElement(ElementName="CotDelHora")]
		[XmlElement(ElementName="CotDelHora" , IsNullable=true)]
		public string gxTpr_Cotdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtContatoTipo_Cotdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtContatoTipo_Cotdelhora).value ;
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Cotdelhora
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotdelhora; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdelhora = value;
				SetDirty("Cotdelhora");
			}
		}



		[SoapElement(ElementName="CotDelUsuId")]
		[XmlElement(ElementName="CotDelUsuId")]
		public string gxTpr_Cotdelusuid
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotdelusuid; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdelusuid = value;
				SetDirty("Cotdelusuid");
			}
		}




		[SoapElement(ElementName="CotDelUsuNome")]
		[XmlElement(ElementName="CotDelUsuNome")]
		public string gxTpr_Cotdelusunome
		{
			get {
				return gxTv_SdtsdtContatoTipo_Cotdelusunome; 
			}
			set {
				gxTv_SdtsdtContatoTipo_Cotdelusunome = value;
				SetDirty("Cotdelusunome");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtsdtContatoTipo_Cotsigla = "";
			gxTv_SdtsdtContatoTipo_Cotnome = "";
			gxTv_SdtsdtContatoTipo_Cotativo = true;

			gxTv_SdtsdtContatoTipo_Cotdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtContatoTipo_Cotdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtContatoTipo_Cotdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtContatoTipo_Cotdelusuid = "";
			gxTv_SdtsdtContatoTipo_Cotdelusunome = "";
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

		protected int gxTv_SdtsdtContatoTipo_Cotid;
		 

		protected string gxTv_SdtsdtContatoTipo_Cotsigla;
		 

		protected string gxTv_SdtsdtContatoTipo_Cotnome;
		 

		protected bool gxTv_SdtsdtContatoTipo_Cotativo;
		 

		protected bool gxTv_SdtsdtContatoTipo_Cotdel;
		 

		protected DateTime gxTv_SdtsdtContatoTipo_Cotdeldatahora;
		 

		protected DateTime gxTv_SdtsdtContatoTipo_Cotdeldata;
		 

		protected DateTime gxTv_SdtsdtContatoTipo_Cotdelhora;
		 

		protected string gxTv_SdtsdtContatoTipo_Cotdelusuid;
		 

		protected string gxTv_SdtsdtContatoTipo_Cotdelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtContatoTipo", Namespace="agl_tresorygroup")]
	public class SdtsdtContatoTipo_RESTInterface : GxGenericCollectionItem<SdtsdtContatoTipo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtContatoTipo_RESTInterface( ) : base()
		{	
		}

		public SdtsdtContatoTipo_RESTInterface( SdtsdtContatoTipo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CotID", Order=0)]
		public  string gxTpr_Cotid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Cotid, 9, 0));

			}
			set { 
				sdt.gxTpr_Cotid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CotSigla", Order=1)]
		public  string gxTpr_Cotsigla
		{
			get { 
				return sdt.gxTpr_Cotsigla;

			}
			set { 
				 sdt.gxTpr_Cotsigla = value;
			}
		}

		[DataMember(Name="CotNome", Order=2)]
		public  string gxTpr_Cotnome
		{
			get { 
				return sdt.gxTpr_Cotnome;

			}
			set { 
				 sdt.gxTpr_Cotnome = value;
			}
		}

		[DataMember(Name="CotAtivo", Order=3)]
		public bool gxTpr_Cotativo
		{
			get { 
				return sdt.gxTpr_Cotativo;

			}
			set { 
				sdt.gxTpr_Cotativo = value;
			}
		}

		[DataMember(Name="CotDel", Order=4)]
		public bool gxTpr_Cotdel
		{
			get { 
				return sdt.gxTpr_Cotdel;

			}
			set { 
				sdt.gxTpr_Cotdel = value;
			}
		}

		[DataMember(Name="CotDelDataHora", Order=5)]
		public  string gxTpr_Cotdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Cotdeldatahora);

			}
			set { 
				sdt.gxTpr_Cotdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="CotDelData", Order=6)]
		public  string gxTpr_Cotdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Cotdeldata);

			}
			set { 
				sdt.gxTpr_Cotdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="CotDelHora", Order=7)]
		public  string gxTpr_Cotdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Cotdelhora);

			}
			set { 
				sdt.gxTpr_Cotdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="CotDelUsuId", Order=8)]
		public  string gxTpr_Cotdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Cotdelusuid);

			}
			set { 
				 sdt.gxTpr_Cotdelusuid = value;
			}
		}

		[DataMember(Name="CotDelUsuNome", Order=9)]
		public  string gxTpr_Cotdelusunome
		{
			get { 
				return sdt.gxTpr_Cotdelusunome;

			}
			set { 
				 sdt.gxTpr_Cotdelusunome = value;
			}
		}


		#endregion

		public SdtsdtContatoTipo sdt
		{
			get { 
				return (SdtsdtContatoTipo)Sdt;
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
				sdt = new SdtsdtContatoTipo() ;
			}
		}
	}
	#endregion
}