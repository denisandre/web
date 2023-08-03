/*
				   File: type_SdtsdtProduto
			Description: sdtProduto
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
	[XmlRoot(ElementName="sdtProduto")]
	[XmlType(TypeName="sdtProduto" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtProduto : GxUserType
	{
		public SdtsdtProduto( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtProduto_Prdcodigo = "";

			gxTv_SdtsdtProduto_Prdnome = "";

			gxTv_SdtsdtProduto_Prdinshora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProduto_Prdinsdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProduto_Prdinsusuid = "";

			gxTv_SdtsdtProduto_Prdupdhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProduto_Prdupddatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProduto_Prdupdusuid = "";

			gxTv_SdtsdtProduto_Prdtiposigla = "";

			gxTv_SdtsdtProduto_Prdtiponome = "";

			gxTv_SdtsdtProduto_Prddeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProduto_Prddeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProduto_Prddelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtProduto_Prddelusuid = "";

			gxTv_SdtsdtProduto_Prddelusunome = "";

		}

		public SdtsdtProduto(IGxContext context)
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
			AddObjectProperty("PrdID", gxTpr_Prdid, false);


			AddObjectProperty("PrdCodigo", gxTpr_Prdcodigo, false);


			AddObjectProperty("PrdNome", gxTpr_Prdnome, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Prdinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Prdinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Prdinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PrdInsData", sDateCnv, false);



			datetime_STZ = gxTpr_Prdinshora;
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
			AddObjectProperty("PrdInsHora", sDateCnv, false);



			datetime_STZ = gxTpr_Prdinsdatahora;
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
			AddObjectProperty("PrdInsDataHora", sDateCnv, false);



			AddObjectProperty("PrdInsUsuID", gxTpr_Prdinsusuid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Prdupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Prdupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Prdupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("PrdUpdData", sDateCnv, false);



			datetime_STZ = gxTpr_Prdupdhora;
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
			AddObjectProperty("PrdUpdHora", sDateCnv, false);



			datetime_STZ = gxTpr_Prdupddatahora;
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
			AddObjectProperty("PrdUpdDataHora", sDateCnv, false);



			AddObjectProperty("PrdUpdUsuID", gxTpr_Prdupdusuid, false);


			AddObjectProperty("PrdAtivo", gxTpr_Prdativo, false);


			AddObjectProperty("PrdTipoID", gxTpr_Prdtipoid, false);


			AddObjectProperty("PrdTipoSigla", gxTpr_Prdtiposigla, false);


			AddObjectProperty("PrdTipoNome", gxTpr_Prdtiponome, false);


			AddObjectProperty("PrdDel", gxTpr_Prddel, false);


			datetime_STZ = gxTpr_Prddeldatahora;
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
			AddObjectProperty("PrdDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Prddeldata;
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
			AddObjectProperty("PrdDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Prddelhora;
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
			AddObjectProperty("PrdDelHora", sDateCnv, false);



			AddObjectProperty("PrdDelUsuId", gxTpr_Prddelusuid, false);


			AddObjectProperty("PrdDelUsuNome", gxTpr_Prddelusunome, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PrdID")]
		[XmlElement(ElementName="PrdID")]
		public Guid gxTpr_Prdid
		{
			get {
				return gxTv_SdtsdtProduto_Prdid; 
			}
			set {
				gxTv_SdtsdtProduto_Prdid = value;
				SetDirty("Prdid");
			}
		}




		[SoapElement(ElementName="PrdCodigo")]
		[XmlElement(ElementName="PrdCodigo")]
		public string gxTpr_Prdcodigo
		{
			get {
				return gxTv_SdtsdtProduto_Prdcodigo; 
			}
			set {
				gxTv_SdtsdtProduto_Prdcodigo = value;
				SetDirty("Prdcodigo");
			}
		}




		[SoapElement(ElementName="PrdNome")]
		[XmlElement(ElementName="PrdNome")]
		public string gxTpr_Prdnome
		{
			get {
				return gxTv_SdtsdtProduto_Prdnome; 
			}
			set {
				gxTv_SdtsdtProduto_Prdnome = value;
				SetDirty("Prdnome");
			}
		}



		[SoapElement(ElementName="PrdInsData")]
		[XmlElement(ElementName="PrdInsData" , IsNullable=true)]
		public string gxTpr_Prdinsdata_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prdinsdata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtProduto_Prdinsdata).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prdinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prdinsdata
		{
			get {
				return gxTv_SdtsdtProduto_Prdinsdata; 
			}
			set {
				gxTv_SdtsdtProduto_Prdinsdata = value;
				SetDirty("Prdinsdata");
			}
		}


		[SoapElement(ElementName="PrdInsHora")]
		[XmlElement(ElementName="PrdInsHora" , IsNullable=true)]
		public string gxTpr_Prdinshora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prdinshora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProduto_Prdinshora).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prdinshora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prdinshora
		{
			get {
				return gxTv_SdtsdtProduto_Prdinshora; 
			}
			set {
				gxTv_SdtsdtProduto_Prdinshora = value;
				SetDirty("Prdinshora");
			}
		}


		[SoapElement(ElementName="PrdInsDataHora")]
		[XmlElement(ElementName="PrdInsDataHora" , IsNullable=true)]
		public string gxTpr_Prdinsdatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prdinsdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProduto_Prdinsdatahora).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prdinsdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prdinsdatahora
		{
			get {
				return gxTv_SdtsdtProduto_Prdinsdatahora; 
			}
			set {
				gxTv_SdtsdtProduto_Prdinsdatahora = value;
				SetDirty("Prdinsdatahora");
			}
		}



		[SoapElement(ElementName="PrdInsUsuID")]
		[XmlElement(ElementName="PrdInsUsuID")]
		public string gxTpr_Prdinsusuid
		{
			get {
				return gxTv_SdtsdtProduto_Prdinsusuid; 
			}
			set {
				gxTv_SdtsdtProduto_Prdinsusuid = value;
				SetDirty("Prdinsusuid");
			}
		}



		[SoapElement(ElementName="PrdUpdData")]
		[XmlElement(ElementName="PrdUpdData" , IsNullable=true)]
		public string gxTpr_Prdupddata_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prdupddata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtProduto_Prdupddata).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prdupddata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prdupddata
		{
			get {
				return gxTv_SdtsdtProduto_Prdupddata; 
			}
			set {
				gxTv_SdtsdtProduto_Prdupddata = value;
				SetDirty("Prdupddata");
			}
		}


		[SoapElement(ElementName="PrdUpdHora")]
		[XmlElement(ElementName="PrdUpdHora" , IsNullable=true)]
		public string gxTpr_Prdupdhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prdupdhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProduto_Prdupdhora).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prdupdhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prdupdhora
		{
			get {
				return gxTv_SdtsdtProduto_Prdupdhora; 
			}
			set {
				gxTv_SdtsdtProduto_Prdupdhora = value;
				SetDirty("Prdupdhora");
			}
		}


		[SoapElement(ElementName="PrdUpdDataHora")]
		[XmlElement(ElementName="PrdUpdDataHora" , IsNullable=true)]
		public string gxTpr_Prdupddatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prdupddatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProduto_Prdupddatahora).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prdupddatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prdupddatahora
		{
			get {
				return gxTv_SdtsdtProduto_Prdupddatahora; 
			}
			set {
				gxTv_SdtsdtProduto_Prdupddatahora = value;
				SetDirty("Prdupddatahora");
			}
		}



		[SoapElement(ElementName="PrdUpdUsuID")]
		[XmlElement(ElementName="PrdUpdUsuID")]
		public string gxTpr_Prdupdusuid
		{
			get {
				return gxTv_SdtsdtProduto_Prdupdusuid; 
			}
			set {
				gxTv_SdtsdtProduto_Prdupdusuid = value;
				SetDirty("Prdupdusuid");
			}
		}




		[SoapElement(ElementName="PrdAtivo")]
		[XmlElement(ElementName="PrdAtivo")]
		public bool gxTpr_Prdativo
		{
			get {
				return gxTv_SdtsdtProduto_Prdativo; 
			}
			set {
				gxTv_SdtsdtProduto_Prdativo = value;
				SetDirty("Prdativo");
			}
		}




		[SoapElement(ElementName="PrdTipoID")]
		[XmlElement(ElementName="PrdTipoID")]
		public int gxTpr_Prdtipoid
		{
			get {
				return gxTv_SdtsdtProduto_Prdtipoid; 
			}
			set {
				gxTv_SdtsdtProduto_Prdtipoid = value;
				SetDirty("Prdtipoid");
			}
		}




		[SoapElement(ElementName="PrdTipoSigla")]
		[XmlElement(ElementName="PrdTipoSigla")]
		public string gxTpr_Prdtiposigla
		{
			get {
				return gxTv_SdtsdtProduto_Prdtiposigla; 
			}
			set {
				gxTv_SdtsdtProduto_Prdtiposigla = value;
				SetDirty("Prdtiposigla");
			}
		}




		[SoapElement(ElementName="PrdTipoNome")]
		[XmlElement(ElementName="PrdTipoNome")]
		public string gxTpr_Prdtiponome
		{
			get {
				return gxTv_SdtsdtProduto_Prdtiponome; 
			}
			set {
				gxTv_SdtsdtProduto_Prdtiponome = value;
				SetDirty("Prdtiponome");
			}
		}




		[SoapElement(ElementName="PrdDel")]
		[XmlElement(ElementName="PrdDel")]
		public bool gxTpr_Prddel
		{
			get {
				return gxTv_SdtsdtProduto_Prddel; 
			}
			set {
				gxTv_SdtsdtProduto_Prddel = value;
				SetDirty("Prddel");
			}
		}



		[SoapElement(ElementName="PrdDelDataHora")]
		[XmlElement(ElementName="PrdDelDataHora" , IsNullable=true)]
		public string gxTpr_Prddeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prddeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProduto_Prddeldatahora).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prddeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prddeldatahora
		{
			get {
				return gxTv_SdtsdtProduto_Prddeldatahora; 
			}
			set {
				gxTv_SdtsdtProduto_Prddeldatahora = value;
				SetDirty("Prddeldatahora");
			}
		}


		[SoapElement(ElementName="PrdDelData")]
		[XmlElement(ElementName="PrdDelData" , IsNullable=true)]
		public string gxTpr_Prddeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prddeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProduto_Prddeldata).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prddeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prddeldata
		{
			get {
				return gxTv_SdtsdtProduto_Prddeldata; 
			}
			set {
				gxTv_SdtsdtProduto_Prddeldata = value;
				SetDirty("Prddeldata");
			}
		}


		[SoapElement(ElementName="PrdDelHora")]
		[XmlElement(ElementName="PrdDelHora" , IsNullable=true)]
		public string gxTpr_Prddelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtProduto_Prddelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtProduto_Prddelhora).value ;
			}
			set {
				gxTv_SdtsdtProduto_Prddelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Prddelhora
		{
			get {
				return gxTv_SdtsdtProduto_Prddelhora; 
			}
			set {
				gxTv_SdtsdtProduto_Prddelhora = value;
				SetDirty("Prddelhora");
			}
		}



		[SoapElement(ElementName="PrdDelUsuId")]
		[XmlElement(ElementName="PrdDelUsuId")]
		public string gxTpr_Prddelusuid
		{
			get {
				return gxTv_SdtsdtProduto_Prddelusuid; 
			}
			set {
				gxTv_SdtsdtProduto_Prddelusuid = value;
				SetDirty("Prddelusuid");
			}
		}




		[SoapElement(ElementName="PrdDelUsuNome")]
		[XmlElement(ElementName="PrdDelUsuNome")]
		public string gxTpr_Prddelusunome
		{
			get {
				return gxTv_SdtsdtProduto_Prddelusunome; 
			}
			set {
				gxTv_SdtsdtProduto_Prddelusunome = value;
				SetDirty("Prddelusunome");
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
			gxTv_SdtsdtProduto_Prdcodigo = "";
			gxTv_SdtsdtProduto_Prdnome = "";

			gxTv_SdtsdtProduto_Prdinshora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProduto_Prdinsdatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProduto_Prdinsusuid = "";

			gxTv_SdtsdtProduto_Prdupdhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProduto_Prdupddatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProduto_Prdupdusuid = "";
			gxTv_SdtsdtProduto_Prdativo = true;

			gxTv_SdtsdtProduto_Prdtiposigla = "";
			gxTv_SdtsdtProduto_Prdtiponome = "";

			gxTv_SdtsdtProduto_Prddeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProduto_Prddeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProduto_Prddelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtProduto_Prddelusuid = "";
			gxTv_SdtsdtProduto_Prddelusunome = "";
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

		protected Guid gxTv_SdtsdtProduto_Prdid;
		 

		protected string gxTv_SdtsdtProduto_Prdcodigo;
		 

		protected string gxTv_SdtsdtProduto_Prdnome;
		 

		protected DateTime gxTv_SdtsdtProduto_Prdinsdata;
		 

		protected DateTime gxTv_SdtsdtProduto_Prdinshora;
		 

		protected DateTime gxTv_SdtsdtProduto_Prdinsdatahora;
		 

		protected string gxTv_SdtsdtProduto_Prdinsusuid;
		 

		protected DateTime gxTv_SdtsdtProduto_Prdupddata;
		 

		protected DateTime gxTv_SdtsdtProduto_Prdupdhora;
		 

		protected DateTime gxTv_SdtsdtProduto_Prdupddatahora;
		 

		protected string gxTv_SdtsdtProduto_Prdupdusuid;
		 

		protected bool gxTv_SdtsdtProduto_Prdativo;
		 

		protected int gxTv_SdtsdtProduto_Prdtipoid;
		 

		protected string gxTv_SdtsdtProduto_Prdtiposigla;
		 

		protected string gxTv_SdtsdtProduto_Prdtiponome;
		 

		protected bool gxTv_SdtsdtProduto_Prddel;
		 

		protected DateTime gxTv_SdtsdtProduto_Prddeldatahora;
		 

		protected DateTime gxTv_SdtsdtProduto_Prddeldata;
		 

		protected DateTime gxTv_SdtsdtProduto_Prddelhora;
		 

		protected string gxTv_SdtsdtProduto_Prddelusuid;
		 

		protected string gxTv_SdtsdtProduto_Prddelusunome;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtProduto", Namespace="agl_tresorygroup")]
	public class SdtsdtProduto_RESTInterface : GxGenericCollectionItem<SdtsdtProduto>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtProduto_RESTInterface( ) : base()
		{	
		}

		public SdtsdtProduto_RESTInterface( SdtsdtProduto psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PrdID", Order=0)]
		public Guid gxTpr_Prdid
		{
			get { 
				return sdt.gxTpr_Prdid;

			}
			set { 
				sdt.gxTpr_Prdid = value;
			}
		}

		[DataMember(Name="PrdCodigo", Order=1)]
		public  string gxTpr_Prdcodigo
		{
			get { 
				return sdt.gxTpr_Prdcodigo;

			}
			set { 
				 sdt.gxTpr_Prdcodigo = value;
			}
		}

		[DataMember(Name="PrdNome", Order=2)]
		public  string gxTpr_Prdnome
		{
			get { 
				return sdt.gxTpr_Prdnome;

			}
			set { 
				 sdt.gxTpr_Prdnome = value;
			}
		}

		[DataMember(Name="PrdInsData", Order=3)]
		public  string gxTpr_Prdinsdata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Prdinsdata);

			}
			set { 
				sdt.gxTpr_Prdinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PrdInsHora", Order=4)]
		public  string gxTpr_Prdinshora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Prdinshora);

			}
			set { 
				sdt.gxTpr_Prdinshora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrdInsDataHora", Order=5)]
		public  string gxTpr_Prdinsdatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Prdinsdatahora);

			}
			set { 
				sdt.gxTpr_Prdinsdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrdInsUsuID", Order=6)]
		public  string gxTpr_Prdinsusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Prdinsusuid);

			}
			set { 
				 sdt.gxTpr_Prdinsusuid = value;
			}
		}

		[DataMember(Name="PrdUpdData", Order=7)]
		public  string gxTpr_Prdupddata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Prdupddata);

			}
			set { 
				sdt.gxTpr_Prdupddata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="PrdUpdHora", Order=8)]
		public  string gxTpr_Prdupdhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Prdupdhora);

			}
			set { 
				sdt.gxTpr_Prdupdhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrdUpdDataHora", Order=9)]
		public  string gxTpr_Prdupddatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Prdupddatahora);

			}
			set { 
				sdt.gxTpr_Prdupddatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrdUpdUsuID", Order=10)]
		public  string gxTpr_Prdupdusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Prdupdusuid);

			}
			set { 
				 sdt.gxTpr_Prdupdusuid = value;
			}
		}

		[DataMember(Name="PrdAtivo", Order=11)]
		public bool gxTpr_Prdativo
		{
			get { 
				return sdt.gxTpr_Prdativo;

			}
			set { 
				sdt.gxTpr_Prdativo = value;
			}
		}

		[DataMember(Name="PrdTipoID", Order=12)]
		public  string gxTpr_Prdtipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Prdtipoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Prdtipoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="PrdTipoSigla", Order=13)]
		public  string gxTpr_Prdtiposigla
		{
			get { 
				return sdt.gxTpr_Prdtiposigla;

			}
			set { 
				 sdt.gxTpr_Prdtiposigla = value;
			}
		}

		[DataMember(Name="PrdTipoNome", Order=14)]
		public  string gxTpr_Prdtiponome
		{
			get { 
				return sdt.gxTpr_Prdtiponome;

			}
			set { 
				 sdt.gxTpr_Prdtiponome = value;
			}
		}

		[DataMember(Name="PrdDel", Order=15)]
		public bool gxTpr_Prddel
		{
			get { 
				return sdt.gxTpr_Prddel;

			}
			set { 
				sdt.gxTpr_Prddel = value;
			}
		}

		[DataMember(Name="PrdDelDataHora", Order=16)]
		public  string gxTpr_Prddeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Prddeldatahora);

			}
			set { 
				sdt.gxTpr_Prddeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrdDelData", Order=17)]
		public  string gxTpr_Prddeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Prddeldata);

			}
			set { 
				sdt.gxTpr_Prddeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrdDelHora", Order=18)]
		public  string gxTpr_Prddelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Prddelhora);

			}
			set { 
				sdt.gxTpr_Prddelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="PrdDelUsuId", Order=19)]
		public  string gxTpr_Prddelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Prddelusuid);

			}
			set { 
				 sdt.gxTpr_Prddelusuid = value;
			}
		}

		[DataMember(Name="PrdDelUsuNome", Order=20)]
		public  string gxTpr_Prddelusunome
		{
			get { 
				return sdt.gxTpr_Prddelusunome;

			}
			set { 
				 sdt.gxTpr_Prddelusunome = value;
			}
		}


		#endregion

		public SdtsdtProduto sdt
		{
			get { 
				return (SdtsdtProduto)Sdt;
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
				sdt = new SdtsdtProduto() ;
			}
		}
	}
	#endregion
}