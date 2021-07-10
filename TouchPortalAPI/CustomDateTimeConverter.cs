using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
namespace TouchPortalAPI
{
	public class CustomDateTimeConverter : IsoDateTimeConverter
	{
		public CustomDateTimeConverter()
		{
			base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.000Z";
		}
	}
}
