/*
				   File: type_SdtsdtDocumentoTipo
			Description: sdtDocumentoTipo
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
	[XmlRoot(ElementName="sdtDocumentoTipo")]
	[XmlType(TypeName="sdtDocumentoTipo" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtDocumentoTipo : GxUserType
	{
		public SdtsdtDocumentoTipo( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtDocumentoTipo_Doctiposigla = "";

			gxTv_SdtsdtDocumentoTipo_Doctiponome = "";

			gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumentoTipo_Doctipodelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumentoTipo_Doctipodelusuid = "";

			gxTv_SdtsdtDocumentoTipo_Doctipodelusunome = "";

		}

		public SdtsdtDocumentoTipo(IGxContext context)
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
			AddObjectProperty("DocTipoID", gxTpr_Doctipoid, false);


			AddObjectProperty("DocTipoSigla", gxTpr_Doctiposigla, false);


			AddObjectProperty("DocTipoNome", gxTpr_Doctiponome, false);


			AddObjectProperty("DocTipoAtivo", gxTpr_Doctipoativo, false);


			AddObjectProperty("DocTipoDel", gxTpr_Doctipodel, false);


			datetime_STZ = gxTpr_Doctipodeldatahora;
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
			AddObjectProperty("DocTipoDelDataHora", sDateCnv, false);



			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Doctipodeldata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Doctipodeldata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Doctipodeldata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("DocTipoDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Doctipodelhora;
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
			AddObjectProperty("DocTipoDelHora", sDateCnv, false);



			AddObjectProperty("DocTipoDelUsuID", gxTpr_Doctipodelusuid, false);


			AddObjectProperty("DocTipoDelUsuNome", gxTpr_Doctipodelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocTipoID")]
		[XmlElement(ElementName="DocTipoID")]
		public int gxTpr_Doctipoid
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipoid; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipoid = value;
				SetDirty("Doctipoid");
			}
		}




		[SoapElement(ElementName="DocTipoSigla")]
		[XmlElement(ElementName="DocTipoSigla")]
		public string gxTpr_Doctiposigla
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctiposigla; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctiposigla = value;
				SetDirty("Doctiposigla");
			}
		}




		[SoapElement(ElementName="DocTipoNome")]
		[XmlElement(ElementName="DocTipoNome")]
		public string gxTpr_Doctiponome
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctiponome; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctiponome = value;
				SetDirty("Doctiponome");
			}
		}




		[SoapElement(ElementName="DocTipoAtivo")]
		[XmlElement(ElementName="DocTipoAtivo")]
		public bool gxTpr_Doctipoativo
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipoativo; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipoativo = value;
				SetDirty("Doctipoativo");
			}
		}




		[SoapElement(ElementName="DocTipoDel")]
		[XmlElement(ElementName="DocTipoDel")]
		public bool gxTpr_Doctipodel
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipodel; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodel = value;
				SetDirty("Doctipodel");
			}
		}



		[SoapElement(ElementName="DocTipoDelDataHora")]
		[XmlElement(ElementName="DocTipoDelDataHora" , IsNullable=true)]
		public string gxTpr_Doctipodeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora).value ;
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Doctipodeldatahora
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora = value;
				SetDirty("Doctipodeldatahora");
			}
		}


		[SoapElement(ElementName="DocTipoDelData")]
		[XmlElement(ElementName="DocTipoDelData" , IsNullable=true)]
		public string gxTpr_Doctipodeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumentoTipo_Doctipodeldata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtDocumentoTipo_Doctipodeldata).value ;
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Doctipodeldata
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipodeldata; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodeldata = value;
				SetDirty("Doctipodeldata");
			}
		}


		[SoapElement(ElementName="DocTipoDelHora")]
		[XmlElement(ElementName="DocTipoDelHora" , IsNullable=true)]
		public string gxTpr_Doctipodelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumentoTipo_Doctipodelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumentoTipo_Doctipodelhora).value ;
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Doctipodelhora
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipodelhora; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodelhora = value;
				SetDirty("Doctipodelhora");
			}
		}



		[SoapElement(ElementName="DocTipoDelUsuID")]
		[XmlElement(ElementName="DocTipoDelUsuID")]
		public string gxTpr_Doctipodelusuid
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipodelusuid; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodelusuid = value;
				SetDirty("Doctipodelusuid");
			}
		}




		[SoapElement(ElementName="DocTipoDelUsuNome")]
		[XmlElement(ElementName="DocTipoDelUsuNome")]
		public string gxTpr_Doctipodelusunome
		{
			get {
				return gxTv_SdtsdtDocumentoTipo_Doctipodelusunome; 
			}
			set {
				gxTv_SdtsdtDocumentoTipo_Doctipodelusunome = value;
				SetDirty("Doctipodelusunome");
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
			gxTv_SdtsdtDocumentoTipo_Doctiposigla = "";
			gxTv_SdtsdtDocumentoTipo_Doctiponome = "";
			gxTv_SdtsdtDocumentoTipo_Doctipoativo = true;

			gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumentoTipo_Doctipodelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumentoTipo_Doctipodelusuid = "";
			gxTv_SdtsdtDocumentoTipo_Doctipodelusunome = "";
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

		protected int gxTv_SdtsdtDocumentoTipo_Doctipoid;
		 

		protected string gxTv_SdtsdtDocumentoTipo_Doctiposigla;
		 

		protected string gxTv_SdtsdtDocumentoTipo_Doctiponome;
		 

		protected bool gxTv_SdtsdtDocumentoTipo_Doctipoativo;
		 

		protected bool gxTv_SdtsdtDocumentoTipo_Doctipodel;
		 

		protected DateTime gxTv_SdtsdtDocumentoTipo_Doctipodeldatahora;
		 

		protected DateTime gxTv_SdtsdtDocumentoTipo_Doctipodeldata;
		 

		protected DateTime gxTv_SdtsdtDocumentoTipo_Doctipodelhora;
		 

		protected string gxTv_SdtsdtDocumentoTipo_Doctipodelusuid;
		 

		protected string gxTv_SdtsdtDocumentoTipo_Doctipodelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtDocumentoTipo", Namespace="agl_tresorygroup")]
	public class SdtsdtDocumentoTipo_RESTInterface : GxGenericCollectionItem<SdtsdtDocumentoTipo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtDocumentoTipo_RESTInterface( ) : base()
		{	
		}

		public SdtsdtDocumentoTipo_RESTInterface( SdtsdtDocumentoTipo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DocTipoID", Order=0)]
		public  string gxTpr_Doctipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Doctipoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Doctipoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocTipoSigla", Order=1)]
		public  string gxTpr_Doctiposigla
		{
			get { 
				return sdt.gxTpr_Doctiposigla;

			}
			set { 
				 sdt.gxTpr_Doctiposigla = value;
			}
		}

		[DataMember(Name="DocTipoNome", Order=2)]
		public  string gxTpr_Doctiponome
		{
			get { 
				return sdt.gxTpr_Doctiponome;

			}
			set { 
				 sdt.gxTpr_Doctiponome = value;
			}
		}

		[DataMember(Name="DocTipoAtivo", Order=3)]
		public bool gxTpr_Doctipoativo
		{
			get { 
				return sdt.gxTpr_Doctipoativo;

			}
			set { 
				sdt.gxTpr_Doctipoativo = value;
			}
		}

		[DataMember(Name="DocTipoDel", Order=4)]
		public bool gxTpr_Doctipodel
		{
			get { 
				return sdt.gxTpr_Doctipodel;

			}
			set { 
				sdt.gxTpr_Doctipodel = value;
			}
		}

		[DataMember(Name="DocTipoDelDataHora", Order=5)]
		public  string gxTpr_Doctipodeldatahora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Doctipodeldatahora);

			}
			set { 
				sdt.gxTpr_Doctipodeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocTipoDelData", Order=6)]
		public  string gxTpr_Doctipodeldata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Doctipodeldata);

			}
			set { 
				sdt.gxTpr_Doctipodeldata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="DocTipoDelHora", Order=7)]
		public  string gxTpr_Doctipodelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Doctipodelhora);

			}
			set { 
				sdt.gxTpr_Doctipodelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocTipoDelUsuID", Order=8)]
		public  string gxTpr_Doctipodelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Doctipodelusuid);

			}
			set { 
				 sdt.gxTpr_Doctipodelusuid = value;
			}
		}

		[DataMember(Name="DocTipoDelUsuNome", Order=9)]
		public  string gxTpr_Doctipodelusunome
		{
			get { 
				return sdt.gxTpr_Doctipodelusunome;

			}
			set { 
				 sdt.gxTpr_Doctipodelusunome = value;
			}
		}


		#endregion

		public SdtsdtDocumentoTipo sdt
		{
			get { 
				return (SdtsdtDocumentoTipo)Sdt;
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
				sdt = new SdtsdtDocumentoTipo() ;
			}
		}
	}
	#endregion
}