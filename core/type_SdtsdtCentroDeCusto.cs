/*
				   File: type_SdtsdtCentroDeCusto
			Description: sdtCentroDeCusto
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
	[XmlRoot(ElementName="sdtCentroDeCusto")]
	[XmlType(TypeName="sdtCentroDeCusto" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtCentroDeCusto : GxUserType
	{
		public SdtsdtCentroDeCusto( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtCentroDeCusto_Ccusigla = "";

			gxTv_SdtsdtCentroDeCusto_Ccunome = "";

			gxTv_SdtsdtCentroDeCusto_Ccudeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtCentroDeCusto_Ccudeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtCentroDeCusto_Ccudelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtCentroDeCusto_Ccudelusuid = "";

			gxTv_SdtsdtCentroDeCusto_Ccudelusunome = "";

		}

		public SdtsdtCentroDeCusto(IGxContext context)
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
			AddObjectProperty("CcuID", gxTpr_Ccuid, false);


			AddObjectProperty("CcuSigla", gxTpr_Ccusigla, false);


			AddObjectProperty("CcuNome", gxTpr_Ccunome, false);


			AddObjectProperty("CcuAtivo", gxTpr_Ccuativo, false);


			AddObjectProperty("CcuDel", gxTpr_Ccudel, false);


			datetime_STZ = gxTpr_Ccudeldatahora;
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
			AddObjectProperty("CcuDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Ccudeldata;
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
			AddObjectProperty("CcuDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Ccudelhora;
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
			AddObjectProperty("CcuDelHora", sDateCnv, false);



			AddObjectProperty("CcuDelUsuId", gxTpr_Ccudelusuid, false);


			AddObjectProperty("CcuDelUsuNome", gxTpr_Ccudelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CcuID")]
		[XmlElement(ElementName="CcuID")]
		public int gxTpr_Ccuid
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccuid; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccuid = value;
				SetDirty("Ccuid");
			}
		}




		[SoapElement(ElementName="CcuSigla")]
		[XmlElement(ElementName="CcuSigla")]
		public string gxTpr_Ccusigla
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccusigla; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccusigla = value;
				SetDirty("Ccusigla");
			}
		}




		[SoapElement(ElementName="CcuNome")]
		[XmlElement(ElementName="CcuNome")]
		public string gxTpr_Ccunome
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccunome; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccunome = value;
				SetDirty("Ccunome");
			}
		}




		[SoapElement(ElementName="CcuAtivo")]
		[XmlElement(ElementName="CcuAtivo")]
		public bool gxTpr_Ccuativo
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccuativo; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccuativo = value;
				SetDirty("Ccuativo");
			}
		}




		[SoapElement(ElementName="CcuDel")]
		[XmlElement(ElementName="CcuDel")]
		public bool gxTpr_Ccudel
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccudel; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudel = value;
				SetDirty("Ccudel");
			}
		}



		[SoapElement(ElementName="CcuDelDataHora")]
		[XmlElement(ElementName="CcuDelDataHora" , IsNullable=true)]
		public string gxTpr_Ccudeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtCentroDeCusto_Ccudeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtCentroDeCusto_Ccudeldatahora).value ;
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ccudeldatahora
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccudeldatahora; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudeldatahora = value;
				SetDirty("Ccudeldatahora");
			}
		}


		[SoapElement(ElementName="CcuDelData")]
		[XmlElement(ElementName="CcuDelData" , IsNullable=true)]
		public string gxTpr_Ccudeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtCentroDeCusto_Ccudeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtCentroDeCusto_Ccudeldata).value ;
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ccudeldata
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccudeldata; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudeldata = value;
				SetDirty("Ccudeldata");
			}
		}


		[SoapElement(ElementName="CcuDelHora")]
		[XmlElement(ElementName="CcuDelHora" , IsNullable=true)]
		public string gxTpr_Ccudelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtCentroDeCusto_Ccudelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtCentroDeCusto_Ccudelhora).value ;
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ccudelhora
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccudelhora; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudelhora = value;
				SetDirty("Ccudelhora");
			}
		}



		[SoapElement(ElementName="CcuDelUsuId")]
		[XmlElement(ElementName="CcuDelUsuId")]
		public string gxTpr_Ccudelusuid
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccudelusuid; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudelusuid = value;
				SetDirty("Ccudelusuid");
			}
		}




		[SoapElement(ElementName="CcuDelUsuNome")]
		[XmlElement(ElementName="CcuDelUsuNome")]
		public string gxTpr_Ccudelusunome
		{
			get {
				return gxTv_SdtsdtCentroDeCusto_Ccudelusunome; 
			}
			set {
				gxTv_SdtsdtCentroDeCusto_Ccudelusunome = value;
				SetDirty("Ccudelusunome");
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
			gxTv_SdtsdtCentroDeCusto_Ccusigla = "";
			gxTv_SdtsdtCentroDeCusto_Ccunome = "";
			gxTv_SdtsdtCentroDeCusto_Ccuativo = true;

			gxTv_SdtsdtCentroDeCusto_Ccudeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtCentroDeCusto_Ccudeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtCentroDeCusto_Ccudelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtCentroDeCusto_Ccudelusuid = "";
			gxTv_SdtsdtCentroDeCusto_Ccudelusunome = "";
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

		protected int gxTv_SdtsdtCentroDeCusto_Ccuid;
		 

		protected string gxTv_SdtsdtCentroDeCusto_Ccusigla;
		 

		protected string gxTv_SdtsdtCentroDeCusto_Ccunome;
		 

		protected bool gxTv_SdtsdtCentroDeCusto_Ccuativo;
		 

		protected bool gxTv_SdtsdtCentroDeCusto_Ccudel;
		 

		protected DateTime gxTv_SdtsdtCentroDeCusto_Ccudeldatahora;
		 

		protected DateTime gxTv_SdtsdtCentroDeCusto_Ccudeldata;
		 

		protected DateTime gxTv_SdtsdtCentroDeCusto_Ccudelhora;
		 

		protected string gxTv_SdtsdtCentroDeCusto_Ccudelusuid;
		 

		protected string gxTv_SdtsdtCentroDeCusto_Ccudelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtCentroDeCusto", Namespace="agl_tresorygroup")]
	public class SdtsdtCentroDeCusto_RESTInterface : GxGenericCollectionItem<SdtsdtCentroDeCusto>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtCentroDeCusto_RESTInterface( ) : base()
		{	
		}

		public SdtsdtCentroDeCusto_RESTInterface( SdtsdtCentroDeCusto psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CcuID", Order=0)]
		public  string gxTpr_Ccuid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ccuid, 9, 0));

			}
			set { 
				sdt.gxTpr_Ccuid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CcuSigla", Order=1)]
		public  string gxTpr_Ccusigla
		{
			get { 
				return sdt.gxTpr_Ccusigla;

			}
			set { 
				 sdt.gxTpr_Ccusigla = value;
			}
		}

		[DataMember(Name="CcuNome", Order=2)]
		public  string gxTpr_Ccunome
		{
			get { 
				return sdt.gxTpr_Ccunome;

			}
			set { 
				 sdt.gxTpr_Ccunome = value;
			}
		}

		[DataMember(Name="CcuAtivo", Order=3)]
		public bool gxTpr_Ccuativo
		{
			get { 
				return sdt.gxTpr_Ccuativo;

			}
			set { 
				sdt.gxTpr_Ccuativo = value;
			}
		}

		[DataMember(Name="CcuDel", Order=4)]
		public bool gxTpr_Ccudel
		{
			get { 
				return sdt.gxTpr_Ccudel;

			}
			set { 
				sdt.gxTpr_Ccudel = value;
			}
		}

		[DataMember(Name="CcuDelDataHora", Order=5)]
		public  string gxTpr_Ccudeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Ccudeldatahora);

			}
			set { 
				sdt.gxTpr_Ccudeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="CcuDelData", Order=6)]
		public  string gxTpr_Ccudeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Ccudeldata);

			}
			set { 
				sdt.gxTpr_Ccudeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="CcuDelHora", Order=7)]
		public  string gxTpr_Ccudelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Ccudelhora);

			}
			set { 
				sdt.gxTpr_Ccudelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="CcuDelUsuId", Order=8)]
		public  string gxTpr_Ccudelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ccudelusuid);

			}
			set { 
				 sdt.gxTpr_Ccudelusuid = value;
			}
		}

		[DataMember(Name="CcuDelUsuNome", Order=9)]
		public  string gxTpr_Ccudelusunome
		{
			get { 
				return sdt.gxTpr_Ccudelusunome;

			}
			set { 
				 sdt.gxTpr_Ccudelusunome = value;
			}
		}


		#endregion

		public SdtsdtCentroDeCusto sdt
		{
			get { 
				return (SdtsdtCentroDeCusto)Sdt;
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
				sdt = new SdtsdtCentroDeCusto() ;
			}
		}
	}
	#endregion
}