/*
				   File: type_SdtsdtRetorno
			Description: sdtRetorno
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
	[XmlRoot(ElementName="sdtRetorno")]
	[XmlType(TypeName="sdtRetorno" , Namespace="agl_tresorygroup" )]
	[Serializable]
	public class SdtsdtRetorno : GxUserType
	{
		public SdtsdtRetorno( )
		{
			/* Constructor for serialization */
			gxTv_SdtsdtRetorno_Message = "";

		}

		public SdtsdtRetorno(IGxContext context)
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
			AddObjectProperty("success", gxTpr_Success, false);


			AddObjectProperty("message", gxTpr_Message, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="success")]
		[XmlElement(ElementName="success")]
		public bool gxTpr_Success
		{
			get {
				return gxTv_SdtsdtRetorno_Success; 
			}
			set {
				gxTv_SdtsdtRetorno_Success = value;
				SetDirty("Success");
			}
		}




		[SoapElement(ElementName="message")]
		[XmlElement(ElementName="message")]
		public string gxTpr_Message
		{
			get {
				return gxTv_SdtsdtRetorno_Message; 
			}
			set {
				gxTv_SdtsdtRetorno_Message = value;
				SetDirty("Message");
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
			gxTv_SdtsdtRetorno_Message = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtsdtRetorno_Success;
		 

		protected string gxTv_SdtsdtRetorno_Message;
		 


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"sdtRetorno", Namespace="agl_tresorygroup")]
	public class SdtsdtRetorno_RESTInterface : GxGenericCollectionItem<SdtsdtRetorno>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtsdtRetorno_RESTInterface( ) : base()
		{	
		}

		public SdtsdtRetorno_RESTInterface( SdtsdtRetorno psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="success", Order=0)]
		public bool gxTpr_Success
		{
			get { 
				return sdt.gxTpr_Success;

			}
			set { 
				sdt.gxTpr_Success = value;
			}
		}

		[DataMember(Name="message", Order=1)]
		public  string gxTpr_Message
		{
			get { 
				return sdt.gxTpr_Message;

			}
			set { 
				 sdt.gxTpr_Message = value;
			}
		}


		#endregion

		public SdtsdtRetorno sdt
		{
			get { 
				return (SdtsdtRetorno)Sdt;
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
				sdt = new SdtsdtRetorno() ;
			}
		}
	}
	#endregion
}