/*
				   File: type_SdtsdtGenero
			Description: sdtGenero
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
	[XmlRoot(ElementName="sdtGenero")]
	[XmlType(TypeName="sdtGenero" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtGenero : GxUserType
	{
		public SdtsdtGenero( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtGenero_Gensigla = "";

			gxTv_SdtsdtGenero_Gennome = "";

			gxTv_SdtsdtGenero_Gendeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtGenero_Gendeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtGenero_Gendelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtGenero_Gendelusuid = "";

			gxTv_SdtsdtGenero_Gendelusunome = "";

		}

		public SdtsdtGenero(IGxContext context)
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
			AddObjectProperty("GenID", gxTpr_Genid, false);


			AddObjectProperty("GenSigla", gxTpr_Gensigla, false);


			AddObjectProperty("GenNome", gxTpr_Gennome, false);


			AddObjectProperty("GenAtivo", gxTpr_Genativo, false);


			AddObjectProperty("GenDel", gxTpr_Gendel, false);


			datetime_STZ = gxTpr_Gendeldatahora;
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
			AddObjectProperty("GenDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Gendeldata;
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
			AddObjectProperty("GenDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Gendelhora;
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
			AddObjectProperty("GenDelHora", sDateCnv, false);



			AddObjectProperty("GenDelUsuId", gxTpr_Gendelusuid, false);


			AddObjectProperty("GenDelUsuNome", gxTpr_Gendelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="GenID")]
		[XmlElement(ElementName="GenID")]
		public int gxTpr_Genid
		{
			get {
				return gxTv_SdtsdtGenero_Genid; 
			}
			set {
				gxTv_SdtsdtGenero_Genid = value;
				SetDirty("Genid");
			}
		}




		[SoapElement(ElementName="GenSigla")]
		[XmlElement(ElementName="GenSigla")]
		public string gxTpr_Gensigla
		{
			get {
				return gxTv_SdtsdtGenero_Gensigla; 
			}
			set {
				gxTv_SdtsdtGenero_Gensigla = value;
				SetDirty("Gensigla");
			}
		}




		[SoapElement(ElementName="GenNome")]
		[XmlElement(ElementName="GenNome")]
		public string gxTpr_Gennome
		{
			get {
				return gxTv_SdtsdtGenero_Gennome; 
			}
			set {
				gxTv_SdtsdtGenero_Gennome = value;
				SetDirty("Gennome");
			}
		}




		[SoapElement(ElementName="GenAtivo")]
		[XmlElement(ElementName="GenAtivo")]
		public bool gxTpr_Genativo
		{
			get {
				return gxTv_SdtsdtGenero_Genativo; 
			}
			set {
				gxTv_SdtsdtGenero_Genativo = value;
				SetDirty("Genativo");
			}
		}




		[SoapElement(ElementName="GenDel")]
		[XmlElement(ElementName="GenDel")]
		public bool gxTpr_Gendel
		{
			get {
				return gxTv_SdtsdtGenero_Gendel; 
			}
			set {
				gxTv_SdtsdtGenero_Gendel = value;
				SetDirty("Gendel");
			}
		}



		[SoapElement(ElementName="GenDelDataHora")]
		[XmlElement(ElementName="GenDelDataHora" , IsNullable=true)]
		public string gxTpr_Gendeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtGenero_Gendeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtGenero_Gendeldatahora).value ;
			}
			set {
				gxTv_SdtsdtGenero_Gendeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Gendeldatahora
		{
			get {
				return gxTv_SdtsdtGenero_Gendeldatahora; 
			}
			set {
				gxTv_SdtsdtGenero_Gendeldatahora = value;
				SetDirty("Gendeldatahora");
			}
		}


		[SoapElement(ElementName="GenDelData")]
		[XmlElement(ElementName="GenDelData" , IsNullable=true)]
		public string gxTpr_Gendeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtGenero_Gendeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtGenero_Gendeldata).value ;
			}
			set {
				gxTv_SdtsdtGenero_Gendeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Gendeldata
		{
			get {
				return gxTv_SdtsdtGenero_Gendeldata; 
			}
			set {
				gxTv_SdtsdtGenero_Gendeldata = value;
				SetDirty("Gendeldata");
			}
		}


		[SoapElement(ElementName="GenDelHora")]
		[XmlElement(ElementName="GenDelHora" , IsNullable=true)]
		public string gxTpr_Gendelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtGenero_Gendelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtGenero_Gendelhora).value ;
			}
			set {
				gxTv_SdtsdtGenero_Gendelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Gendelhora
		{
			get {
				return gxTv_SdtsdtGenero_Gendelhora; 
			}
			set {
				gxTv_SdtsdtGenero_Gendelhora = value;
				SetDirty("Gendelhora");
			}
		}



		[SoapElement(ElementName="GenDelUsuId")]
		[XmlElement(ElementName="GenDelUsuId")]
		public string gxTpr_Gendelusuid
		{
			get {
				return gxTv_SdtsdtGenero_Gendelusuid; 
			}
			set {
				gxTv_SdtsdtGenero_Gendelusuid = value;
				SetDirty("Gendelusuid");
			}
		}




		[SoapElement(ElementName="GenDelUsuNome")]
		[XmlElement(ElementName="GenDelUsuNome")]
		public string gxTpr_Gendelusunome
		{
			get {
				return gxTv_SdtsdtGenero_Gendelusunome; 
			}
			set {
				gxTv_SdtsdtGenero_Gendelusunome = value;
				SetDirty("Gendelusunome");
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
			gxTv_SdtsdtGenero_Gensigla = "";
			gxTv_SdtsdtGenero_Gennome = "";
			gxTv_SdtsdtGenero_Genativo = true;

			gxTv_SdtsdtGenero_Gendeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtGenero_Gendeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtGenero_Gendelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtGenero_Gendelusuid = "";
			gxTv_SdtsdtGenero_Gendelusunome = "";
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

		protected int gxTv_SdtsdtGenero_Genid;
		 

		protected string gxTv_SdtsdtGenero_Gensigla;
		 

		protected string gxTv_SdtsdtGenero_Gennome;
		 

		protected bool gxTv_SdtsdtGenero_Genativo;
		 

		protected bool gxTv_SdtsdtGenero_Gendel;
		 

		protected DateTime gxTv_SdtsdtGenero_Gendeldatahora;
		 

		protected DateTime gxTv_SdtsdtGenero_Gendeldata;
		 

		protected DateTime gxTv_SdtsdtGenero_Gendelhora;
		 

		protected string gxTv_SdtsdtGenero_Gendelusuid;
		 

		protected string gxTv_SdtsdtGenero_Gendelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtGenero", Namespace="agl_tresorygroup")]
	public class SdtsdtGenero_RESTInterface : GxGenericCollectionItem<SdtsdtGenero>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtGenero_RESTInterface( ) : base()
		{	
		}

		public SdtsdtGenero_RESTInterface( SdtsdtGenero psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="GenID", Order=0)]
		public  string gxTpr_Genid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Genid, 9, 0));

			}
			set { 
				sdt.gxTpr_Genid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="GenSigla", Order=1)]
		public  string gxTpr_Gensigla
		{
			get { 
				return sdt.gxTpr_Gensigla;

			}
			set { 
				 sdt.gxTpr_Gensigla = value;
			}
		}

		[DataMember(Name="GenNome", Order=2)]
		public  string gxTpr_Gennome
		{
			get { 
				return sdt.gxTpr_Gennome;

			}
			set { 
				 sdt.gxTpr_Gennome = value;
			}
		}

		[DataMember(Name="GenAtivo", Order=3)]
		public bool gxTpr_Genativo
		{
			get { 
				return sdt.gxTpr_Genativo;

			}
			set { 
				sdt.gxTpr_Genativo = value;
			}
		}

		[DataMember(Name="GenDel", Order=4)]
		public bool gxTpr_Gendel
		{
			get { 
				return sdt.gxTpr_Gendel;

			}
			set { 
				sdt.gxTpr_Gendel = value;
			}
		}

		[DataMember(Name="GenDelDataHora", Order=5)]
		public  string gxTpr_Gendeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Gendeldatahora);

			}
			set { 
				sdt.gxTpr_Gendeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="GenDelData", Order=6)]
		public  string gxTpr_Gendeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Gendeldata);

			}
			set { 
				sdt.gxTpr_Gendeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="GenDelHora", Order=7)]
		public  string gxTpr_Gendelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Gendelhora);

			}
			set { 
				sdt.gxTpr_Gendelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="GenDelUsuId", Order=8)]
		public  string gxTpr_Gendelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gendelusuid);

			}
			set { 
				 sdt.gxTpr_Gendelusuid = value;
			}
		}

		[DataMember(Name="GenDelUsuNome", Order=9)]
		public  string gxTpr_Gendelusunome
		{
			get { 
				return sdt.gxTpr_Gendelusunome;

			}
			set { 
				 sdt.gxTpr_Gendelusunome = value;
			}
		}


		#endregion

		public SdtsdtGenero sdt
		{
			get { 
				return (SdtsdtGenero)Sdt;
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
				sdt = new SdtsdtGenero() ;
			}
		}
	}
	#endregion
}