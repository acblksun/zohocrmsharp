﻿using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Deveel.Web.Zoho {
	[Serializable]
	public sealed class ZohoResponseException : Exception {
		internal ZohoResponseException(ZohoResponse response)
			: base(response.Message) {
			ErrorCode = response.Code;
		}

		internal ZohoResponseException(SerializationInfo info, StreamingContext context) {
			ErrorCode = info.GetString("ErrorCode");
		}

	    internal ZohoResponseException(string code, string message)
            :base(message)
	    {
	        ErrorCode = code;
	    }

	    public string ErrorCode { get; private set; }

		public override void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("ErrorCode", ErrorCode);
			base.GetObjectData(info, context);
		}
	}
}