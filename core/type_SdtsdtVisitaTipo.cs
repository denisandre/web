/*
				   File: type_SdtsdtVisitaTipo
			Description: sdtVisitaTipo
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
	[XmlRoot(ElementName="sdtVisitaTipo")]
	[XmlType(TypeName="sdtVisitaTipo" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtVisitaTipo : GxUserType
	{
		public SdtsdtVisitaTipo( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtVisitaTipo_Vitsigla = "";

			gxTv_SdtsdtVisitaTipo_Vitnome = "";

			gxTv_SdtsdtVisitaTipo_Vitdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisitaTipo_Vitdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisitaTipo_Vitdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtVisitaTipo_Vitdelusuid = "";

			gxTv_SdtsdtVisitaTipo_Vitdelusunome = "";

		}

		public SdtsdtVisitaTipo(IGxContext context)
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
			AddObjectProperty("VitID", gxTpr_Vitid, false);


			AddObjectProperty("VitSigla", gxTpr_Vitsigla, false);


			AddObjectProperty("VitNome", gxTpr_Vitnome, false);


			AddObjectProperty("VitDel", gxTpr_Vitdel, false);


			datetime_STZ = gxTpr_Vitdeldatahora;
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
			AddObjectProperty("VitDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Vitdeldata;
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
			AddObjectProperty("VitDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Vitdelhora;
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
			AddObjectProperty("VitDelHora", sDateCnv, false);



			AddObjectProperty("VitDelUsuId", gxTpr_Vitdelusuid, false);


			AddObjectProperty("VitDelUsuNome", gxTpr_Vitdelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="VitID")]
		[XmlElement(ElementName="VitID")]
		public int gxTpr_Vitid
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitid; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitid = value;
				SetDirty("Vitid");
			}
		}




		[SoapElement(ElementName="VitSigla")]
		[XmlElement(ElementName="VitSigla")]
		public string gxTpr_Vitsigla
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitsigla; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitsigla = value;
				SetDirty("Vitsigla");
			}
		}




		[SoapElement(ElementName="VitNome")]
		[XmlElement(ElementName="VitNome")]
		public string gxTpr_Vitnome
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitnome; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitnome = value;
				SetDirty("Vitnome");
			}
		}




		[SoapElement(ElementName="VitDel")]
		[XmlElement(ElementName="VitDel")]
		public bool gxTpr_Vitdel
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitdel; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdel = value;
				SetDirty("Vitdel");
			}
		}



		[SoapElement(ElementName="VitDelDataHora")]
		[XmlElement(ElementName="VitDelDataHora" , IsNullable=true)]
		public string gxTpr_Vitdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisitaTipo_Vitdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisitaTipo_Vitdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vitdeldatahora
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitdeldatahora; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdeldatahora = value;
				SetDirty("Vitdeldatahora");
			}
		}


		[SoapElement(ElementName="VitDelData")]
		[XmlElement(ElementName="VitDelData" , IsNullable=true)]
		public string gxTpr_Vitdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisitaTipo_Vitdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisitaTipo_Vitdeldata).value ;
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vitdeldata
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitdeldata; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdeldata = value;
				SetDirty("Vitdeldata");
			}
		}


		[SoapElement(ElementName="VitDelHora")]
		[XmlElement(ElementName="VitDelHora" , IsNullable=true)]
		public string gxTpr_Vitdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtVisitaTipo_Vitdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtVisitaTipo_Vitdelhora).value ;
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Vitdelhora
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitdelhora; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdelhora = value;
				SetDirty("Vitdelhora");
			}
		}



		[SoapElement(ElementName="VitDelUsuId")]
		[XmlElement(ElementName="VitDelUsuId")]
		public string gxTpr_Vitdelusuid
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitdelusuid; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdelusuid = value;
				SetDirty("Vitdelusuid");
			}
		}




		[SoapElement(ElementName="VitDelUsuNome")]
		[XmlElement(ElementName="VitDelUsuNome")]
		public string gxTpr_Vitdelusunome
		{
			get {
				return gxTv_SdtsdtVisitaTipo_Vitdelusunome; 
			}
			set {
				gxTv_SdtsdtVisitaTipo_Vitdelusunome = value;
				SetDirty("Vitdelusunome");
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
			gxTv_SdtsdtVisitaTipo_Vitsigla = "";
			gxTv_SdtsdtVisitaTipo_Vitnome = "";

			gxTv_SdtsdtVisitaTipo_Vitdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisitaTipo_Vitdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisitaTipo_Vitdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtVisitaTipo_Vitdelusuid = "";
			gxTv_SdtsdtVisitaTipo_Vitdelusunome = "";
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

		protected int gxTv_SdtsdtVisitaTipo_Vitid;
		 

		protected string gxTv_SdtsdtVisitaTipo_Vitsigla;
		 

		protected string gxTv_SdtsdtVisitaTipo_Vitnome;
		 

		protected bool gxTv_SdtsdtVisitaTipo_Vitdel;
		 

		protected DateTime gxTv_SdtsdtVisitaTipo_Vitdeldatahora;
		 

		protected DateTime gxTv_SdtsdtVisitaTipo_Vitdeldata;
		 

		protected DateTime gxTv_SdtsdtVisitaTipo_Vitdelhora;
		 

		protected string gxTv_SdtsdtVisitaTipo_Vitdelusuid;
		 

		protected string gxTv_SdtsdtVisitaTipo_Vitdelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtVisitaTipo", Namespace="agl_tresorygroup")]
	public class SdtsdtVisitaTipo_RESTInterface : GxGenericCollectionItem<SdtsdtVisitaTipo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtVisitaTipo_RESTInterface( ) : base()
		{	
		}

		public SdtsdtVisitaTipo_RESTInterface( SdtsdtVisitaTipo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="VitID", Order=0)]
		public  string gxTpr_Vitid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Vitid, 9, 0));

			}
			set { 
				sdt.gxTpr_Vitid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="VitSigla", Order=1)]
		public  string gxTpr_Vitsigla
		{
			get { 
				return sdt.gxTpr_Vitsigla;

			}
			set { 
				 sdt.gxTpr_Vitsigla = value;
			}
		}

		[DataMember(Name="VitNome", Order=2)]
		public  string gxTpr_Vitnome
		{
			get { 
				return sdt.gxTpr_Vitnome;

			}
			set { 
				 sdt.gxTpr_Vitnome = value;
			}
		}

		[DataMember(Name="VitDel", Order=3)]
		public bool gxTpr_Vitdel
		{
			get { 
				return sdt.gxTpr_Vitdel;

			}
			set { 
				sdt.gxTpr_Vitdel = value;
			}
		}

		[DataMember(Name="VitDelDataHora", Order=4)]
		public  string gxTpr_Vitdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Vitdeldatahora);

			}
			set { 
				sdt.gxTpr_Vitdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VitDelData", Order=5)]
		public  string gxTpr_Vitdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Vitdeldata);

			}
			set { 
				sdt.gxTpr_Vitdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VitDelHora", Order=6)]
		public  string gxTpr_Vitdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Vitdelhora);

			}
			set { 
				sdt.gxTpr_Vitdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="VitDelUsuId", Order=7)]
		public  string gxTpr_Vitdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Vitdelusuid);

			}
			set { 
				 sdt.gxTpr_Vitdelusuid = value;
			}
		}

		[DataMember(Name="VitDelUsuNome", Order=8)]
		public  string gxTpr_Vitdelusunome
		{
			get { 
				return sdt.gxTpr_Vitdelusunome;

			}
			set { 
				 sdt.gxTpr_Vitdelusunome = value;
			}
		}


		#endregion

		public SdtsdtVisitaTipo sdt
		{
			get { 
				return (SdtsdtVisitaTipo)Sdt;
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
				sdt = new SdtsdtVisitaTipo() ;
			}
		}
	}
	#endregion
}