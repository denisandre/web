/*
				   File: type_SdtsdtProdutoTipo
			Description: sdtProdutoTipo
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
	[XmlRoot(ElementName="sdtProdutoTipo")]
	[XmlType(TypeName="sdtProdutoTipo" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtProdutoTipo : GxUserType
	{
		public SdtsdtProdutoTipo( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtProdutoTipo_Prtsigla = "";

			gxTv_SdtsdtProdutoTipo_Prtnome = "";

			gxTv_SdtsdtProdutoTipo_Prtdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProdutoTipo_Prtdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProdutoTipo_Prtdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProdutoTipo_Prtdelusuid = "";

			gxTv_SdtsdtProdutoTipo_Prtdelusunome = "";

		}

		public SdtsdtProdutoTipo(IGxContext context)
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
			AddObjectProperty("PrtID", gxTpr_Prtid, false);


			AddObjectProperty("PrtSigla", gxTpr_Prtsigla, false);


			AddObjectProperty("PrtNome", gxTpr_Prtnome, false);


			AddObjectProperty("PrtAtivo", gxTpr_Prtativo, false);


			AddObjectProperty("PrtDel", gxTpr_Prtdel, false);


			datetime_STZ = gxTpr_Prtdeldatahora;
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
			AddObjectProperty("PrtDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Prtdeldata;
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
			AddObjectProperty("PrtDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Prtdelhora;
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
			AddObjectProperty("PrtDelHora", sDateCnv, false);



			AddObjectProperty("PrtDelUsuId", gxTpr_Prtdelusuid, false);


			AddObjectProperty("PrtDelUsuNome", gxTpr_Prtdelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PrtID")]
		[XmlElement(ElementName="PrtID")]
		public int gxTpr_Prtid
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtid; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtid = value;
				SetDirty("Prtid");
			}
		}




		[SoapElement(ElementName="PrtSigla")]
		[XmlElement(ElementName="PrtSigla")]
		public string gxTpr_Prtsigla
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtsigla; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtsigla = value;
				SetDirty("Prtsigla");
			}
		}




		[SoapElement(ElementName="PrtNome")]
		[XmlElement(ElementName="PrtNome")]
		public string gxTpr_Prtnome
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtnome; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtnome = value;
				SetDirty("Prtnome");
			}
		}




		[SoapElement(ElementName="PrtAtivo")]
		[XmlElement(ElementName="PrtAtivo")]
		public bool gxTpr_Prtativo
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtativo; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtativo = value;
				SetDirty("Prtativo");
			}
		}




		[SoapElement(ElementName="PrtDel")]
		[XmlElement(ElementName="PrtDel")]
		public bool gxTpr_Prtdel
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtdel; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdel = value;
				SetDirty("Prtdel");
			}
		}



		[SoapElement(ElementName="PrtDelDataHora")]
		[XmlElement(ElementName="PrtDelDataHora" , IsNullable=true)]
		public string gxTpr_Prtdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProdutoTipo_Prtdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProdutoTipo_Prtdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prtdeldatahora
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtdeldatahora; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdeldatahora = value;
				SetDirty("Prtdeldatahora");
			}
		}


		[SoapElement(ElementName="PrtDelData")]
		[XmlElement(ElementName="PrtDelData" , IsNullable=true)]
		public string gxTpr_Prtdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtProdutoTipo_Prtdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProdutoTipo_Prtdeldata).value ;
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prtdeldata
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtdeldata; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdeldata = value;
				SetDirty("Prtdeldata");
			}
		}


		[SoapElement(ElementName="PrtDelHora")]
		[XmlElement(ElementName="PrtDelHora" , IsNullable=true)]
		public string gxTpr_Prtdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProdutoTipo_Prtdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProdutoTipo_Prtdelhora).value ;
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prtdelhora
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtdelhora; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdelhora = value;
				SetDirty("Prtdelhora");
			}
		}



		[SoapElement(ElementName="PrtDelUsuId")]
		[XmlElement(ElementName="PrtDelUsuId")]
		public string gxTpr_Prtdelusuid
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtdelusuid; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdelusuid = value;
				SetDirty("Prtdelusuid");
			}
		}




		[SoapElement(ElementName="PrtDelUsuNome")]
		[XmlElement(ElementName="PrtDelUsuNome")]
		public string gxTpr_Prtdelusunome
		{
			get {
				return gxTv_SdtsdtProdutoTipo_Prtdelusunome; 
			}
			set {
				gxTv_SdtsdtProdutoTipo_Prtdelusunome = value;
				SetDirty("Prtdelusunome");
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
			gxTv_SdtsdtProdutoTipo_Prtsigla = "";
			gxTv_SdtsdtProdutoTipo_Prtnome = "";
			gxTv_SdtsdtProdutoTipo_Prtativo = true;

			gxTv_SdtsdtProdutoTipo_Prtdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProdutoTipo_Prtdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProdutoTipo_Prtdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProdutoTipo_Prtdelusuid = "";
			gxTv_SdtsdtProdutoTipo_Prtdelusunome = "";
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

		protected int gxTv_SdtsdtProdutoTipo_Prtid;
		 

		protected string gxTv_SdtsdtProdutoTipo_Prtsigla;
		 

		protected string gxTv_SdtsdtProdutoTipo_Prtnome;
		 

		protected bool gxTv_SdtsdtProdutoTipo_Prtativo;
		 

		protected bool gxTv_SdtsdtProdutoTipo_Prtdel;
		 

		protected DateTime gxTv_SdtsdtProdutoTipo_Prtdeldatahora;
		 

		protected DateTime gxTv_SdtsdtProdutoTipo_Prtdeldata;
		 

		protected DateTime gxTv_SdtsdtProdutoTipo_Prtdelhora;
		 

		protected string gxTv_SdtsdtProdutoTipo_Prtdelusuid;
		 

		protected string gxTv_SdtsdtProdutoTipo_Prtdelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtProdutoTipo", Namespace="agl_tresorygroup")]
	public class SdtsdtProdutoTipo_RESTInterface : GxGenericCollectionItem<SdtsdtProdutoTipo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtProdutoTipo_RESTInterface( ) : base()
		{	
		}

		public SdtsdtProdutoTipo_RESTInterface( SdtsdtProdutoTipo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PrtID", Order=0)]
		public  string gxTpr_Prtid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Prtid, 9, 0));

			}
			set { 
				sdt.gxTpr_Prtid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PrtSigla", Order=1)]
		public  string gxTpr_Prtsigla
		{
			get { 
				return sdt.gxTpr_Prtsigla;

			}
			set { 
				 sdt.gxTpr_Prtsigla = value;
			}
		}

		[DataMember(Name="PrtNome", Order=2)]
		public  string gxTpr_Prtnome
		{
			get { 
				return sdt.gxTpr_Prtnome;

			}
			set { 
				 sdt.gxTpr_Prtnome = value;
			}
		}

		[DataMember(Name="PrtAtivo", Order=3)]
		public bool gxTpr_Prtativo
		{
			get { 
				return sdt.gxTpr_Prtativo;

			}
			set { 
				sdt.gxTpr_Prtativo = value;
			}
		}

		[DataMember(Name="PrtDel", Order=4)]
		public bool gxTpr_Prtdel
		{
			get { 
				return sdt.gxTpr_Prtdel;

			}
			set { 
				sdt.gxTpr_Prtdel = value;
			}
		}

		[DataMember(Name="PrtDelDataHora", Order=5)]
		public  string gxTpr_Prtdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Prtdeldatahora);

			}
			set { 
				sdt.gxTpr_Prtdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrtDelData", Order=6)]
		public  string gxTpr_Prtdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Prtdeldata);

			}
			set { 
				sdt.gxTpr_Prtdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrtDelHora", Order=7)]
		public  string gxTpr_Prtdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Prtdelhora);

			}
			set { 
				sdt.gxTpr_Prtdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrtDelUsuId", Order=8)]
		public  string gxTpr_Prtdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Prtdelusuid);

			}
			set { 
				 sdt.gxTpr_Prtdelusuid = value;
			}
		}

		[DataMember(Name="PrtDelUsuNome", Order=9)]
		public  string gxTpr_Prtdelusunome
		{
			get { 
				return sdt.gxTpr_Prtdelusunome;

			}
			set { 
				 sdt.gxTpr_Prtdelusunome = value;
			}
		}


		#endregion

		public SdtsdtProdutoTipo sdt
		{
			get { 
				return (SdtsdtProdutoTipo)Sdt;
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
				sdt = new SdtsdtProdutoTipo() ;
			}
		}
	}
	#endregion
}