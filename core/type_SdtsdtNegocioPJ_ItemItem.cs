/*
				   File: type_SdtsdtNegocioPJ_ItemItem
			Description: Item
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
	[XmlRoot(ElementName="sdtNegocioPJ.ItemItem")]
	[XmlType(TypeName="sdtNegocioPJ.ItemItem" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtNegocioPJ_ItemItem : GxUserType
	{
		public SdtsdtNegocioPJ_ItemItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusuid = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusunome = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdcodigo = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdnome = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpobs = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusuid = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusunome = "";

		}

		public SdtsdtNegocioPJ_ItemItem(IGxContext context)
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
			AddObjectProperty("NgpItem", gxTpr_Ngpitem, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Ngpinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Ngpinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Ngpinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("NgpInsData", sDateCnv, false);



			datetime_STZ = gxTpr_Ngpinshora;
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
			AddObjectProperty("NgpInsHora", sDateCnv, false);



			datetime_STZ = gxTpr_Ngpinsdatahora;
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
			AddObjectProperty("NgpInsDataHora", sDateCnv, false);



			AddObjectProperty("NgpInsUsuID", gxTpr_Ngpinsusuid, false);


			AddObjectProperty("NgpInsUsuNome", gxTpr_Ngpinsusunome, false);


			AddObjectProperty("NgpTppID", gxTpr_Ngptppid, false);


			AddObjectProperty("NgpTppPrdID", gxTpr_Ngptppprdid, false);


			AddObjectProperty("NgpTppPrdCodigo", gxTpr_Ngptppprdcodigo, false);


			AddObjectProperty("NgpTppPrdNome", gxTpr_Ngptppprdnome, false);


			AddObjectProperty("NgpTppPrdTipoID", gxTpr_Ngptppprdtipoid, false);


			AddObjectProperty("NgpTppPrdAtivo", gxTpr_Ngptppprdativo, false);


			AddObjectProperty("NgpTpp1Preco", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Ngptpp1preco, 16, 2)), false);


			AddObjectProperty("NgpPreco", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Ngppreco, 16, 2)), false);


			AddObjectProperty("NgpQtde", gxTpr_Ngpqtde, false);


			AddObjectProperty("NgpTotal", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Ngptotal, 16, 2)), false);


			AddObjectProperty("NgpObs", gxTpr_Ngpobs, false);


			AddObjectProperty("NgpDel", gxTpr_Ngpdel, false);


			datetime_STZ = gxTpr_Ngpdeldatahora;
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
			AddObjectProperty("NgpDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Ngpdeldata;
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
			AddObjectProperty("NgpDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Ngpdelhora;
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
			AddObjectProperty("NgpDelHora", sDateCnv, false);



			AddObjectProperty("NgpDelUsuId", gxTpr_Ngpdelusuid, false);


			AddObjectProperty("NgpDelUsuNome", gxTpr_Ngpdelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NgpItem")]
		[XmlElement(ElementName="NgpItem")]
		public int gxTpr_Ngpitem
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpitem; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpitem = value;
				SetDirty("Ngpitem");
			}
		}



		[SoapElement(ElementName="NgpInsData")]
		[XmlElement(ElementName="NgpInsData" , IsNullable=true)]
		public string gxTpr_Ngpinsdata_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdata).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ngpinsdata
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdata; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdata = value;
				SetDirty("Ngpinsdata");
			}
		}


		[SoapElement(ElementName="NgpInsHora")]
		[XmlElement(ElementName="NgpInsHora" , IsNullable=true)]
		public string gxTpr_Ngpinshora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ngpinshora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora = value;
				SetDirty("Ngpinshora");
			}
		}


		[SoapElement(ElementName="NgpInsDataHora")]
		[XmlElement(ElementName="NgpInsDataHora" , IsNullable=true)]
		public string gxTpr_Ngpinsdatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ngpinsdatahora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora = value;
				SetDirty("Ngpinsdatahora");
			}
		}



		[SoapElement(ElementName="NgpInsUsuID")]
		[XmlElement(ElementName="NgpInsUsuID")]
		public string gxTpr_Ngpinsusuid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusuid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusuid = value;
				SetDirty("Ngpinsusuid");
			}
		}




		[SoapElement(ElementName="NgpInsUsuNome")]
		[XmlElement(ElementName="NgpInsUsuNome")]
		public string gxTpr_Ngpinsusunome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusunome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusunome = value;
				SetDirty("Ngpinsusunome");
			}
		}




		[SoapElement(ElementName="NgpTppID")]
		[XmlElement(ElementName="NgpTppID")]
		public Guid gxTpr_Ngptppid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppid = value;
				SetDirty("Ngptppid");
			}
		}




		[SoapElement(ElementName="NgpTppPrdID")]
		[XmlElement(ElementName="NgpTppPrdID")]
		public Guid gxTpr_Ngptppprdid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdid = value;
				SetDirty("Ngptppprdid");
			}
		}




		[SoapElement(ElementName="NgpTppPrdCodigo")]
		[XmlElement(ElementName="NgpTppPrdCodigo")]
		public string gxTpr_Ngptppprdcodigo
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdcodigo; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdcodigo = value;
				SetDirty("Ngptppprdcodigo");
			}
		}




		[SoapElement(ElementName="NgpTppPrdNome")]
		[XmlElement(ElementName="NgpTppPrdNome")]
		public string gxTpr_Ngptppprdnome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdnome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdnome = value;
				SetDirty("Ngptppprdnome");
			}
		}




		[SoapElement(ElementName="NgpTppPrdTipoID")]
		[XmlElement(ElementName="NgpTppPrdTipoID")]
		public int gxTpr_Ngptppprdtipoid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdtipoid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdtipoid = value;
				SetDirty("Ngptppprdtipoid");
			}
		}




		[SoapElement(ElementName="NgpTppPrdAtivo")]
		[XmlElement(ElementName="NgpTppPrdAtivo")]
		public bool gxTpr_Ngptppprdativo
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdativo; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdativo = value;
				SetDirty("Ngptppprdativo");
			}
		}



		[SoapElement(ElementName="NgpTpp1Preco")]
		[XmlElement(ElementName="NgpTpp1Preco")]
		public string gxTpr_Ngptpp1preco_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngptpp1preco, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptpp1preco = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Ngptpp1preco
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptpp1preco; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptpp1preco = value;
				SetDirty("Ngptpp1preco");
			}
		}



		[SoapElement(ElementName="NgpPreco")]
		[XmlElement(ElementName="NgpPreco")]
		public string gxTpr_Ngppreco_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngppreco, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngppreco = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Ngppreco
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngppreco; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngppreco = value;
				SetDirty("Ngppreco");
			}
		}




		[SoapElement(ElementName="NgpQtde")]
		[XmlElement(ElementName="NgpQtde")]
		public int gxTpr_Ngpqtde
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpqtde; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpqtde = value;
				SetDirty("Ngpqtde");
			}
		}



		[SoapElement(ElementName="NgpTotal")]
		[XmlElement(ElementName="NgpTotal")]
		public string gxTpr_Ngptotal_double
		{
			get {
				return Convert.ToString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngptotal, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptotal = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Ngptotal
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngptotal; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngptotal = value;
				SetDirty("Ngptotal");
			}
		}




		[SoapElement(ElementName="NgpObs")]
		[XmlElement(ElementName="NgpObs")]
		public string gxTpr_Ngpobs
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpobs; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpobs = value;
				SetDirty("Ngpobs");
			}
		}




		[SoapElement(ElementName="NgpDel")]
		[XmlElement(ElementName="NgpDel")]
		public bool gxTpr_Ngpdel
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdel; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdel = value;
				SetDirty("Ngpdel");
			}
		}



		[SoapElement(ElementName="NgpDelDataHora")]
		[XmlElement(ElementName="NgpDelDataHora" , IsNullable=true)]
		public string gxTpr_Ngpdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ngpdeldatahora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora = value;
				SetDirty("Ngpdeldatahora");
			}
		}


		[SoapElement(ElementName="NgpDelData")]
		[XmlElement(ElementName="NgpDelData" , IsNullable=true)]
		public string gxTpr_Ngpdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ngpdeldata
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata = value;
				SetDirty("Ngpdeldata");
			}
		}


		[SoapElement(ElementName="NgpDelHora")]
		[XmlElement(ElementName="NgpDelHora" , IsNullable=true)]
		public string gxTpr_Ngpdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora).value ;
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Ngpdelhora
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora = value;
				SetDirty("Ngpdelhora");
			}
		}



		[SoapElement(ElementName="NgpDelUsuId")]
		[XmlElement(ElementName="NgpDelUsuId")]
		public string gxTpr_Ngpdelusuid
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusuid; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusuid = value;
				SetDirty("Ngpdelusuid");
			}
		}




		[SoapElement(ElementName="NgpDelUsuNome")]
		[XmlElement(ElementName="NgpDelUsuNome")]
		public string gxTpr_Ngpdelusunome
		{
			get {
				return gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusunome; 
			}
			set {
				gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusunome = value;
				SetDirty("Ngpdelusunome");
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
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusuid = "";
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusunome = "";


			gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdcodigo = "";
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdnome = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdativo = true;


			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpqtde = 1;

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpobs = "";

			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusuid = "";
			gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusunome = "";
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

		protected int gxTv_SdtsdtNegocioPJ_ItemItem_Ngpitem;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdata;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinshora;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsdatahora;
		 

		protected string gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusuid;
		 

		protected string gxTv_SdtsdtNegocioPJ_ItemItem_Ngpinsusunome;
		 

		protected Guid gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppid;
		 

		protected Guid gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdid;
		 

		protected string gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdcodigo;
		 

		protected string gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdnome;
		 

		protected int gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdtipoid;
		 

		protected bool gxTv_SdtsdtNegocioPJ_ItemItem_Ngptppprdativo;
		 

		protected decimal gxTv_SdtsdtNegocioPJ_ItemItem_Ngptpp1preco;
		 

		protected decimal gxTv_SdtsdtNegocioPJ_ItemItem_Ngppreco;
		 

		protected int gxTv_SdtsdtNegocioPJ_ItemItem_Ngpqtde;
		 

		protected decimal gxTv_SdtsdtNegocioPJ_ItemItem_Ngptotal;
		 

		protected string gxTv_SdtsdtNegocioPJ_ItemItem_Ngpobs;
		 

		protected bool gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdel;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldatahora;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdeldata;
		 

		protected DateTime gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelhora;
		 

		protected string gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusuid;
		 

		protected string gxTv_SdtsdtNegocioPJ_ItemItem_Ngpdelusunome;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"sdtNegocioPJ.ItemItem", Namespace="agl_tresorygroup")]
	public class SdtsdtNegocioPJ_ItemItem_RESTInterface : GxGenericCollectionItem<SdtsdtNegocioPJ_ItemItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtNegocioPJ_ItemItem_RESTInterface( ) : base()
		{	
		}

		public SdtsdtNegocioPJ_ItemItem_RESTInterface( SdtsdtNegocioPJ_ItemItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="NgpItem", Order=0)]
		public  string gxTpr_Ngpitem
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ngpitem, 8, 0));

			}
			set { 
				sdt.gxTpr_Ngpitem = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NgpInsData", Order=1)]
		public  string gxTpr_Ngpinsdata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Ngpinsdata);

			}
			set { 
				sdt.gxTpr_Ngpinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="NgpInsHora", Order=2)]
		public  string gxTpr_Ngpinshora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Ngpinshora);

			}
			set { 
				sdt.gxTpr_Ngpinshora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NgpInsDataHora", Order=3)]
		public  string gxTpr_Ngpinsdatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Ngpinsdatahora);

			}
			set { 
				sdt.gxTpr_Ngpinsdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NgpInsUsuID", Order=4)]
		public  string gxTpr_Ngpinsusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ngpinsusuid);

			}
			set { 
				 sdt.gxTpr_Ngpinsusuid = value;
			}
		}

		[DataMember(Name="NgpInsUsuNome", Order=5)]
		public  string gxTpr_Ngpinsusunome
		{
			get { 
				return sdt.gxTpr_Ngpinsusunome;

			}
			set { 
				 sdt.gxTpr_Ngpinsusunome = value;
			}
		}

		[DataMember(Name="NgpTppID", Order=6)]
		public Guid gxTpr_Ngptppid
		{
			get { 
				return sdt.gxTpr_Ngptppid;

			}
			set { 
				sdt.gxTpr_Ngptppid = value;
			}
		}

		[DataMember(Name="NgpTppPrdID", Order=7)]
		public Guid gxTpr_Ngptppprdid
		{
			get { 
				return sdt.gxTpr_Ngptppprdid;

			}
			set { 
				sdt.gxTpr_Ngptppprdid = value;
			}
		}

		[DataMember(Name="NgpTppPrdCodigo", Order=8)]
		public  string gxTpr_Ngptppprdcodigo
		{
			get { 
				return sdt.gxTpr_Ngptppprdcodigo;

			}
			set { 
				 sdt.gxTpr_Ngptppprdcodigo = value;
			}
		}

		[DataMember(Name="NgpTppPrdNome", Order=9)]
		public  string gxTpr_Ngptppprdnome
		{
			get { 
				return sdt.gxTpr_Ngptppprdnome;

			}
			set { 
				 sdt.gxTpr_Ngptppprdnome = value;
			}
		}

		[DataMember(Name="NgpTppPrdTipoID", Order=10)]
		public  string gxTpr_Ngptppprdtipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ngptppprdtipoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Ngptppprdtipoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NgpTppPrdAtivo", Order=11)]
		public bool gxTpr_Ngptppprdativo
		{
			get { 
				return sdt.gxTpr_Ngptppprdativo;

			}
			set { 
				sdt.gxTpr_Ngptppprdativo = value;
			}
		}

		[DataMember(Name="NgpTpp1Preco", Order=12)]
		public  string gxTpr_Ngptpp1preco
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Ngptpp1preco, 16, 2));

			}
			set { 
				sdt.gxTpr_Ngptpp1preco =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NgpPreco", Order=13)]
		public  string gxTpr_Ngppreco
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Ngppreco, 16, 2));

			}
			set { 
				sdt.gxTpr_Ngppreco =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NgpQtde", Order=14)]
		public  string gxTpr_Ngpqtde
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Ngpqtde, 8, 0));

			}
			set { 
				sdt.gxTpr_Ngpqtde = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NgpTotal", Order=15)]
		public  string gxTpr_Ngptotal
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Ngptotal, 16, 2));

			}
			set { 
				sdt.gxTpr_Ngptotal =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="NgpObs", Order=16)]
		public  string gxTpr_Ngpobs
		{
			get { 
				return sdt.gxTpr_Ngpobs;

			}
			set { 
				 sdt.gxTpr_Ngpobs = value;
			}
		}

		[DataMember(Name="NgpDel", Order=17)]
		public bool gxTpr_Ngpdel
		{
			get { 
				return sdt.gxTpr_Ngpdel;

			}
			set { 
				sdt.gxTpr_Ngpdel = value;
			}
		}

		[DataMember(Name="NgpDelDataHora", Order=18)]
		public  string gxTpr_Ngpdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Ngpdeldatahora);

			}
			set { 
				sdt.gxTpr_Ngpdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NgpDelData", Order=19)]
		public  string gxTpr_Ngpdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Ngpdeldata);

			}
			set { 
				sdt.gxTpr_Ngpdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NgpDelHora", Order=20)]
		public  string gxTpr_Ngpdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Ngpdelhora);

			}
			set { 
				sdt.gxTpr_Ngpdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="NgpDelUsuId", Order=21)]
		public  string gxTpr_Ngpdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ngpdelusuid);

			}
			set { 
				 sdt.gxTpr_Ngpdelusuid = value;
			}
		}

		[DataMember(Name="NgpDelUsuNome", Order=22)]
		public  string gxTpr_Ngpdelusunome
		{
			get { 
				return sdt.gxTpr_Ngpdelusunome;

			}
			set { 
				 sdt.gxTpr_Ngpdelusunome = value;
			}
		}


		#endregion

		public SdtsdtNegocioPJ_ItemItem sdt
		{
			get { 
				return (SdtsdtNegocioPJ_ItemItem)Sdt;
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
				sdt = new SdtsdtNegocioPJ_ItemItem() ;
			}
		}
	}
	#endregion
}