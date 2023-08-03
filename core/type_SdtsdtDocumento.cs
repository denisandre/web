/*
				   File: type_SdtsdtDocumento
			Description: sdtDocumento
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
	[XmlRoot(ElementName="sdtDocumento")]
	[XmlType(TypeName="sdtDocumento" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtDocumento : GxUserType
	{
		public SdtsdtDocumento( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtDocumento_Docversaonomepai = "";

			gxTv_SdtsdtDocumento_Docorigem = "";

			gxTv_SdtsdtDocumento_Docorigemid = "";

			gxTv_SdtsdtDocumento_Docinshora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumento_Docinsdatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumento_Docinsusuid = "";

			gxTv_SdtsdtDocumento_Docupdhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumento_Docupddatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumento_Docupdusuid = "";

			gxTv_SdtsdtDocumento_Docdeldatahora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumento_Docdeldata = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumento_Docdelhora = (DateTime)(DateTime.MinValue);

			gxTv_SdtsdtDocumento_Docdelusuid = "";

			gxTv_SdtsdtDocumento_Docdelusunome = "";

			gxTv_SdtsdtDocumento_Docnome = "";

			gxTv_SdtsdtDocumento_Doctiposigla = "";

			gxTv_SdtsdtDocumento_Doctiponome = "";

		}

		public SdtsdtDocumento(IGxContext context)
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
			AddObjectProperty("DocID", gxTpr_Docid, false);


			AddObjectProperty("DocVersao", gxTpr_Docversao, false);


			AddObjectProperty("DocVersaoIDPai", gxTpr_Docversaoidpai, false);


			AddObjectProperty("DocVersaoNomePai", gxTpr_Docversaonomepai, false);


			AddObjectProperty("DocOrigem", gxTpr_Docorigem, false);


			AddObjectProperty("DocOrigemID", gxTpr_Docorigemid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Docinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Docinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Docinsdata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("DocInsData", sDateCnv, false);



			datetime_STZ = gxTpr_Docinshora;
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
			AddObjectProperty("DocInsHora", sDateCnv, false);



			datetime_STZ = gxTpr_Docinsdatahora;
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
			AddObjectProperty("DocInsDataHora", sDateCnv, false);



			AddObjectProperty("DocInsUsuID", gxTpr_Docinsusuid, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Docupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Docupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Docupddata)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("DocUpdData", sDateCnv, false);



			datetime_STZ = gxTpr_Docupdhora;
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
			AddObjectProperty("DocUpdHora", sDateCnv, false);



			datetime_STZ = gxTpr_Docupddatahora;
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
			AddObjectProperty("DocUpdDataHora", sDateCnv, false);



			AddObjectProperty("DocUpdUsuID", gxTpr_Docupdusuid, false);


			AddObjectProperty("DocDel", gxTpr_Docdel, false);


			datetime_STZ = gxTpr_Docdeldatahora;
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
			AddObjectProperty("DocDelDataHora", sDateCnv, false);



			datetime_STZ = gxTpr_Docdeldata;
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
			AddObjectProperty("DocDelData", sDateCnv, false);



			datetime_STZ = gxTpr_Docdelhora;
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
			AddObjectProperty("DocDelHora", sDateCnv, false);



			AddObjectProperty("DocDelUsuID", gxTpr_Docdelusuid, false);


			AddObjectProperty("DocDelUsuNome", gxTpr_Docdelusunome, false);


			AddObjectProperty("DocNome", gxTpr_Docnome, false);


			AddObjectProperty("DocTipoID", gxTpr_Doctipoid, false);


			AddObjectProperty("DocTipoSigla", gxTpr_Doctiposigla, false);


			AddObjectProperty("DocTipoNome", gxTpr_Doctiponome, false);


			AddObjectProperty("DocTipoAtivo", gxTpr_Doctipoativo, false);


			AddObjectProperty("DocUltArqSeq", gxTpr_Docultarqseq, false);


			AddObjectProperty("DocContrato", gxTpr_Doccontrato, false);


			AddObjectProperty("DocAssinado", gxTpr_Docassinado, false);


			AddObjectProperty("DocAtivo", gxTpr_Docativo, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="DocID")]
		[XmlElement(ElementName="DocID")]
		public Guid gxTpr_Docid
		{
			get {
				return gxTv_SdtsdtDocumento_Docid; 
			}
			set {
				gxTv_SdtsdtDocumento_Docid = value;
				SetDirty("Docid");
			}
		}




		[SoapElement(ElementName="DocVersao")]
		[XmlElement(ElementName="DocVersao")]
		public short gxTpr_Docversao
		{
			get {
				return gxTv_SdtsdtDocumento_Docversao; 
			}
			set {
				gxTv_SdtsdtDocumento_Docversao = value;
				SetDirty("Docversao");
			}
		}




		[SoapElement(ElementName="DocVersaoIDPai")]
		[XmlElement(ElementName="DocVersaoIDPai")]
		public Guid gxTpr_Docversaoidpai
		{
			get {
				return gxTv_SdtsdtDocumento_Docversaoidpai; 
			}
			set {
				gxTv_SdtsdtDocumento_Docversaoidpai = value;
				SetDirty("Docversaoidpai");
			}
		}




		[SoapElement(ElementName="DocVersaoNomePai")]
		[XmlElement(ElementName="DocVersaoNomePai")]
		public string gxTpr_Docversaonomepai
		{
			get {
				return gxTv_SdtsdtDocumento_Docversaonomepai; 
			}
			set {
				gxTv_SdtsdtDocumento_Docversaonomepai = value;
				SetDirty("Docversaonomepai");
			}
		}




		[SoapElement(ElementName="DocOrigem")]
		[XmlElement(ElementName="DocOrigem")]
		public string gxTpr_Docorigem
		{
			get {
				return gxTv_SdtsdtDocumento_Docorigem; 
			}
			set {
				gxTv_SdtsdtDocumento_Docorigem = value;
				SetDirty("Docorigem");
			}
		}




		[SoapElement(ElementName="DocOrigemID")]
		[XmlElement(ElementName="DocOrigemID")]
		public string gxTpr_Docorigemid
		{
			get {
				return gxTv_SdtsdtDocumento_Docorigemid; 
			}
			set {
				gxTv_SdtsdtDocumento_Docorigemid = value;
				SetDirty("Docorigemid");
			}
		}



		[SoapElement(ElementName="DocInsData")]
		[XmlElement(ElementName="DocInsData" , IsNullable=true)]
		public string gxTpr_Docinsdata_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docinsdata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtDocumento_Docinsdata).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docinsdata
		{
			get {
				return gxTv_SdtsdtDocumento_Docinsdata; 
			}
			set {
				gxTv_SdtsdtDocumento_Docinsdata = value;
				SetDirty("Docinsdata");
			}
		}


		[SoapElement(ElementName="DocInsHora")]
		[XmlElement(ElementName="DocInsHora" , IsNullable=true)]
		public string gxTpr_Docinshora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docinshora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumento_Docinshora).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docinshora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docinshora
		{
			get {
				return gxTv_SdtsdtDocumento_Docinshora; 
			}
			set {
				gxTv_SdtsdtDocumento_Docinshora = value;
				SetDirty("Docinshora");
			}
		}


		[SoapElement(ElementName="DocInsDataHora")]
		[XmlElement(ElementName="DocInsDataHora" , IsNullable=true)]
		public string gxTpr_Docinsdatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docinsdatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumento_Docinsdatahora).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docinsdatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docinsdatahora
		{
			get {
				return gxTv_SdtsdtDocumento_Docinsdatahora; 
			}
			set {
				gxTv_SdtsdtDocumento_Docinsdatahora = value;
				SetDirty("Docinsdatahora");
			}
		}



		[SoapElement(ElementName="DocInsUsuID")]
		[XmlElement(ElementName="DocInsUsuID")]
		public string gxTpr_Docinsusuid
		{
			get {
				return gxTv_SdtsdtDocumento_Docinsusuid; 
			}
			set {
				gxTv_SdtsdtDocumento_Docinsusuid = value;
				SetDirty("Docinsusuid");
			}
		}



		[SoapElement(ElementName="DocUpdData")]
		[XmlElement(ElementName="DocUpdData" , IsNullable=true)]
		public string gxTpr_Docupddata_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docupddata == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtsdtDocumento_Docupddata).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docupddata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docupddata
		{
			get {
				return gxTv_SdtsdtDocumento_Docupddata; 
			}
			set {
				gxTv_SdtsdtDocumento_Docupddata = value;
				SetDirty("Docupddata");
			}
		}


		[SoapElement(ElementName="DocUpdHora")]
		[XmlElement(ElementName="DocUpdHora" , IsNullable=true)]
		public string gxTpr_Docupdhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docupdhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumento_Docupdhora).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docupdhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docupdhora
		{
			get {
				return gxTv_SdtsdtDocumento_Docupdhora; 
			}
			set {
				gxTv_SdtsdtDocumento_Docupdhora = value;
				SetDirty("Docupdhora");
			}
		}


		[SoapElement(ElementName="DocUpdDataHora")]
		[XmlElement(ElementName="DocUpdDataHora" , IsNullable=true)]
		public string gxTpr_Docupddatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docupddatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumento_Docupddatahora).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docupddatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docupddatahora
		{
			get {
				return gxTv_SdtsdtDocumento_Docupddatahora; 
			}
			set {
				gxTv_SdtsdtDocumento_Docupddatahora = value;
				SetDirty("Docupddatahora");
			}
		}



		[SoapElement(ElementName="DocUpdUsuID")]
		[XmlElement(ElementName="DocUpdUsuID")]
		public string gxTpr_Docupdusuid
		{
			get {
				return gxTv_SdtsdtDocumento_Docupdusuid; 
			}
			set {
				gxTv_SdtsdtDocumento_Docupdusuid = value;
				SetDirty("Docupdusuid");
			}
		}




		[SoapElement(ElementName="DocDel")]
		[XmlElement(ElementName="DocDel")]
		public bool gxTpr_Docdel
		{
			get {
				return gxTv_SdtsdtDocumento_Docdel; 
			}
			set {
				gxTv_SdtsdtDocumento_Docdel = value;
				SetDirty("Docdel");
			}
		}



		[SoapElement(ElementName="DocDelDataHora")]
		[XmlElement(ElementName="DocDelDataHora" , IsNullable=true)]
		public string gxTpr_Docdeldatahora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docdeldatahora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumento_Docdeldatahora).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docdeldatahora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docdeldatahora
		{
			get {
				return gxTv_SdtsdtDocumento_Docdeldatahora; 
			}
			set {
				gxTv_SdtsdtDocumento_Docdeldatahora = value;
				SetDirty("Docdeldatahora");
			}
		}


		[SoapElement(ElementName="DocDelData")]
		[XmlElement(ElementName="DocDelData" , IsNullable=true)]
		public string gxTpr_Docdeldata_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docdeldata == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumento_Docdeldata).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docdeldata = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docdeldata
		{
			get {
				return gxTv_SdtsdtDocumento_Docdeldata; 
			}
			set {
				gxTv_SdtsdtDocumento_Docdeldata = value;
				SetDirty("Docdeldata");
			}
		}


		[SoapElement(ElementName="DocDelHora")]
		[XmlElement(ElementName="DocDelHora" , IsNullable=true)]
		public string gxTpr_Docdelhora_Nullable
		{
			get {
				if ( gxTv_SdtsdtDocumento_Docdelhora == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtsdtDocumento_Docdelhora).value ;
			}
			set {
				gxTv_SdtsdtDocumento_Docdelhora = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Docdelhora
		{
			get {
				return gxTv_SdtsdtDocumento_Docdelhora; 
			}
			set {
				gxTv_SdtsdtDocumento_Docdelhora = value;
				SetDirty("Docdelhora");
			}
		}



		[SoapElement(ElementName="DocDelUsuID")]
		[XmlElement(ElementName="DocDelUsuID")]
		public string gxTpr_Docdelusuid
		{
			get {
				return gxTv_SdtsdtDocumento_Docdelusuid; 
			}
			set {
				gxTv_SdtsdtDocumento_Docdelusuid = value;
				SetDirty("Docdelusuid");
			}
		}




		[SoapElement(ElementName="DocDelUsuNome")]
		[XmlElement(ElementName="DocDelUsuNome")]
		public string gxTpr_Docdelusunome
		{
			get {
				return gxTv_SdtsdtDocumento_Docdelusunome; 
			}
			set {
				gxTv_SdtsdtDocumento_Docdelusunome = value;
				SetDirty("Docdelusunome");
			}
		}




		[SoapElement(ElementName="DocNome")]
		[XmlElement(ElementName="DocNome")]
		public string gxTpr_Docnome
		{
			get {
				return gxTv_SdtsdtDocumento_Docnome; 
			}
			set {
				gxTv_SdtsdtDocumento_Docnome = value;
				SetDirty("Docnome");
			}
		}




		[SoapElement(ElementName="DocTipoID")]
		[XmlElement(ElementName="DocTipoID")]
		public int gxTpr_Doctipoid
		{
			get {
				return gxTv_SdtsdtDocumento_Doctipoid; 
			}
			set {
				gxTv_SdtsdtDocumento_Doctipoid = value;
				SetDirty("Doctipoid");
			}
		}




		[SoapElement(ElementName="DocTipoSigla")]
		[XmlElement(ElementName="DocTipoSigla")]
		public string gxTpr_Doctiposigla
		{
			get {
				return gxTv_SdtsdtDocumento_Doctiposigla; 
			}
			set {
				gxTv_SdtsdtDocumento_Doctiposigla = value;
				SetDirty("Doctiposigla");
			}
		}




		[SoapElement(ElementName="DocTipoNome")]
		[XmlElement(ElementName="DocTipoNome")]
		public string gxTpr_Doctiponome
		{
			get {
				return gxTv_SdtsdtDocumento_Doctiponome; 
			}
			set {
				gxTv_SdtsdtDocumento_Doctiponome = value;
				SetDirty("Doctiponome");
			}
		}




		[SoapElement(ElementName="DocTipoAtivo")]
		[XmlElement(ElementName="DocTipoAtivo")]
		public bool gxTpr_Doctipoativo
		{
			get {
				return gxTv_SdtsdtDocumento_Doctipoativo; 
			}
			set {
				gxTv_SdtsdtDocumento_Doctipoativo = value;
				SetDirty("Doctipoativo");
			}
		}




		[SoapElement(ElementName="DocUltArqSeq")]
		[XmlElement(ElementName="DocUltArqSeq")]
		public short gxTpr_Docultarqseq
		{
			get {
				return gxTv_SdtsdtDocumento_Docultarqseq; 
			}
			set {
				gxTv_SdtsdtDocumento_Docultarqseq = value;
				SetDirty("Docultarqseq");
			}
		}




		[SoapElement(ElementName="DocContrato")]
		[XmlElement(ElementName="DocContrato")]
		public bool gxTpr_Doccontrato
		{
			get {
				return gxTv_SdtsdtDocumento_Doccontrato; 
			}
			set {
				gxTv_SdtsdtDocumento_Doccontrato = value;
				SetDirty("Doccontrato");
			}
		}




		[SoapElement(ElementName="DocAssinado")]
		[XmlElement(ElementName="DocAssinado")]
		public bool gxTpr_Docassinado
		{
			get {
				return gxTv_SdtsdtDocumento_Docassinado; 
			}
			set {
				gxTv_SdtsdtDocumento_Docassinado = value;
				SetDirty("Docassinado");
			}
		}




		[SoapElement(ElementName="DocAtivo")]
		[XmlElement(ElementName="DocAtivo")]
		public bool gxTpr_Docativo
		{
			get {
				return gxTv_SdtsdtDocumento_Docativo; 
			}
			set {
				gxTv_SdtsdtDocumento_Docativo = value;
				SetDirty("Docativo");
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
			gxTv_SdtsdtDocumento_Docversaonomepai = "";
			gxTv_SdtsdtDocumento_Docorigem = "";
			gxTv_SdtsdtDocumento_Docorigemid = "";

			gxTv_SdtsdtDocumento_Docinshora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumento_Docinsdatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumento_Docinsusuid = "";

			gxTv_SdtsdtDocumento_Docupdhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumento_Docupddatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumento_Docupdusuid = "";
			gxTv_SdtsdtDocumento_Docdel = false;
			gxTv_SdtsdtDocumento_Docdeldatahora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumento_Docdeldata = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumento_Docdelhora = (DateTime)(DateTime.MinValue);
			gxTv_SdtsdtDocumento_Docdelusuid = "";
			gxTv_SdtsdtDocumento_Docdelusunome = "";
			gxTv_SdtsdtDocumento_Docnome = "";

			gxTv_SdtsdtDocumento_Doctiposigla = "";
			gxTv_SdtsdtDocumento_Doctiponome = "";
			gxTv_SdtsdtDocumento_Doctipoativo = true;

			gxTv_SdtsdtDocumento_Doccontrato = false;
			gxTv_SdtsdtDocumento_Docassinado = false;
			gxTv_SdtsdtDocumento_Docativo = true;
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

		protected Guid gxTv_SdtsdtDocumento_Docid;
		 

		protected short gxTv_SdtsdtDocumento_Docversao;
		 

		protected Guid gxTv_SdtsdtDocumento_Docversaoidpai;
		 

		protected string gxTv_SdtsdtDocumento_Docversaonomepai;
		 

		protected string gxTv_SdtsdtDocumento_Docorigem;
		 

		protected string gxTv_SdtsdtDocumento_Docorigemid;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docinsdata;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docinshora;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docinsdatahora;
		 

		protected string gxTv_SdtsdtDocumento_Docinsusuid;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docupddata;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docupdhora;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docupddatahora;
		 

		protected string gxTv_SdtsdtDocumento_Docupdusuid;
		 

		protected bool gxTv_SdtsdtDocumento_Docdel;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docdeldatahora;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docdeldata;
		 

		protected DateTime gxTv_SdtsdtDocumento_Docdelhora;
		 

		protected string gxTv_SdtsdtDocumento_Docdelusuid;
		 

		protected string gxTv_SdtsdtDocumento_Docdelusunome;
		 

		protected string gxTv_SdtsdtDocumento_Docnome;
		 

		protected int gxTv_SdtsdtDocumento_Doctipoid;
		 

		protected string gxTv_SdtsdtDocumento_Doctiposigla;
		 

		protected string gxTv_SdtsdtDocumento_Doctiponome;
		 

		protected bool gxTv_SdtsdtDocumento_Doctipoativo;
		 

		protected short gxTv_SdtsdtDocumento_Docultarqseq;
		 

		protected bool gxTv_SdtsdtDocumento_Doccontrato;
		 

		protected bool gxTv_SdtsdtDocumento_Docassinado;
		 

		protected bool gxTv_SdtsdtDocumento_Docativo;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtDocumento", Namespace="agl_tresorygroup")]
	public class SdtsdtDocumento_RESTInterface : GxGenericCollectionItem<SdtsdtDocumento>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtDocumento_RESTInterface( ) : base()
		{	
		}

		public SdtsdtDocumento_RESTInterface( SdtsdtDocumento psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="DocID", Order=0)]
		public Guid gxTpr_Docid
		{
			get { 
				return sdt.gxTpr_Docid;

			}
			set { 
				sdt.gxTpr_Docid = value;
			}
		}

		[DataMember(Name="DocVersao", Order=1)]
		public short gxTpr_Docversao
		{
			get { 
				return sdt.gxTpr_Docversao;

			}
			set { 
				sdt.gxTpr_Docversao = value;
			}
		}

		[DataMember(Name="DocVersaoIDPai", Order=2)]
		public Guid gxTpr_Docversaoidpai
		{
			get { 
				return sdt.gxTpr_Docversaoidpai;

			}
			set { 
				sdt.gxTpr_Docversaoidpai = value;
			}
		}

		[DataMember(Name="DocVersaoNomePai", Order=3)]
		public  string gxTpr_Docversaonomepai
		{
			get { 
				return sdt.gxTpr_Docversaonomepai;

			}
			set { 
				 sdt.gxTpr_Docversaonomepai = value;
			}
		}

		[DataMember(Name="DocOrigem", Order=4)]
		public  string gxTpr_Docorigem
		{
			get { 
				return sdt.gxTpr_Docorigem;

			}
			set { 
				 sdt.gxTpr_Docorigem = value;
			}
		}

		[DataMember(Name="DocOrigemID", Order=5)]
		public  string gxTpr_Docorigemid
		{
			get { 
				return sdt.gxTpr_Docorigemid;

			}
			set { 
				 sdt.gxTpr_Docorigemid = value;
			}
		}

		[DataMember(Name="DocInsData", Order=6)]
		public  string gxTpr_Docinsdata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Docinsdata);

			}
			set { 
				sdt.gxTpr_Docinsdata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="DocInsHora", Order=7)]
		public  string gxTpr_Docinshora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Docinshora);

			}
			set { 
				sdt.gxTpr_Docinshora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocInsDataHora", Order=8)]
		public  string gxTpr_Docinsdatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Docinsdatahora);

			}
			set { 
				sdt.gxTpr_Docinsdatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocInsUsuID", Order=9)]
		public  string gxTpr_Docinsusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Docinsusuid);

			}
			set { 
				 sdt.gxTpr_Docinsusuid = value;
			}
		}

		[DataMember(Name="DocUpdData", Order=10)]
		public  string gxTpr_Docupddata
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Docupddata);

			}
			set { 
				sdt.gxTpr_Docupddata = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="DocUpdHora", Order=11)]
		public  string gxTpr_Docupdhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Docupdhora);

			}
			set { 
				sdt.gxTpr_Docupdhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocUpdDataHora", Order=12)]
		public  string gxTpr_Docupddatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Docupddatahora);

			}
			set { 
				sdt.gxTpr_Docupddatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocUpdUsuID", Order=13)]
		public  string gxTpr_Docupdusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Docupdusuid);

			}
			set { 
				 sdt.gxTpr_Docupdusuid = value;
			}
		}

		[DataMember(Name="DocDel", Order=14)]
		public bool gxTpr_Docdel
		{
			get { 
				return sdt.gxTpr_Docdel;

			}
			set { 
				sdt.gxTpr_Docdel = value;
			}
		}

		[DataMember(Name="DocDelDataHora", Order=15)]
		public  string gxTpr_Docdeldatahora
		{
			get { 
				return DateTimeUtil.TToC3( sdt.gxTpr_Docdeldatahora);

			}
			set { 
				sdt.gxTpr_Docdeldatahora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocDelData", Order=16)]
		public  string gxTpr_Docdeldata
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Docdeldata);

			}
			set { 
				sdt.gxTpr_Docdeldata = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocDelHora", Order=17)]
		public  string gxTpr_Docdelhora
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Docdelhora);

			}
			set { 
				sdt.gxTpr_Docdelhora = DateTimeUtil.CToT2(value);
			}
		}

		[DataMember(Name="DocDelUsuID", Order=18)]
		public  string gxTpr_Docdelusuid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Docdelusuid);

			}
			set { 
				 sdt.gxTpr_Docdelusuid = value;
			}
		}

		[DataMember(Name="DocDelUsuNome", Order=19)]
		public  string gxTpr_Docdelusunome
		{
			get { 
				return sdt.gxTpr_Docdelusunome;

			}
			set { 
				 sdt.gxTpr_Docdelusunome = value;
			}
		}

		[DataMember(Name="DocNome", Order=20)]
		public  string gxTpr_Docnome
		{
			get { 
				return sdt.gxTpr_Docnome;

			}
			set { 
				 sdt.gxTpr_Docnome = value;
			}
		}

		[DataMember(Name="DocTipoID", Order=21)]
		public  string gxTpr_Doctipoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Doctipoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Doctipoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocTipoSigla", Order=22)]
		public  string gxTpr_Doctiposigla
		{
			get { 
				return sdt.gxTpr_Doctiposigla;

			}
			set { 
				 sdt.gxTpr_Doctiposigla = value;
			}
		}

		[DataMember(Name="DocTipoNome", Order=23)]
		public  string gxTpr_Doctiponome
		{
			get { 
				return sdt.gxTpr_Doctiponome;

			}
			set { 
				 sdt.gxTpr_Doctiponome = value;
			}
		}

		[DataMember(Name="DocTipoAtivo", Order=24)]
		public bool gxTpr_Doctipoativo
		{
			get { 
				return sdt.gxTpr_Doctipoativo;

			}
			set { 
				sdt.gxTpr_Doctipoativo = value;
			}
		}

		[DataMember(Name="DocUltArqSeq", Order=25)]
		public short gxTpr_Docultarqseq
		{
			get { 
				return sdt.gxTpr_Docultarqseq;

			}
			set { 
				sdt.gxTpr_Docultarqseq = value;
			}
		}

		[DataMember(Name="DocContrato", Order=26)]
		public bool gxTpr_Doccontrato
		{
			get { 
				return sdt.gxTpr_Doccontrato;

			}
			set { 
				sdt.gxTpr_Doccontrato = value;
			}
		}

		[DataMember(Name="DocAssinado", Order=27)]
		public bool gxTpr_Docassinado
		{
			get { 
				return sdt.gxTpr_Docassinado;

			}
			set { 
				sdt.gxTpr_Docassinado = value;
			}
		}

		[DataMember(Name="DocAtivo", Order=28)]
		public bool gxTpr_Docativo
		{
			get { 
				return sdt.gxTpr_Docativo;

			}
			set { 
				sdt.gxTpr_Docativo = value;
			}
		}


		#endregion

		public SdtsdtDocumento sdt
		{
			get { 
				return (SdtsdtDocumento)Sdt;
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
				sdt = new SdtsdtDocumento() ;
			}
		}
	}
	#endregion
}