using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.IO.Compression;

namespace TouchPortalAPI
{
	public static class Utils
	{
		public static T FromJson<T>(string o)
		{
			if (string.IsNullOrEmpty(o)) return default(T);

			JsonSerializerSettings settings = new JsonSerializerSettings();

			settings.Formatting = Formatting.None;
			settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.000Z";
			settings.Converters.Add(new CustomDateTimeConverter());

			return JsonConvert.DeserializeObject<T>(o, settings);
		}

		public static string ToJson(object o)
		{
			if (o == null) return "{}";

			JsonSerializerSettings settings = new JsonSerializerSettings();

			settings.Formatting = Formatting.None;
			settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.000Z";
			settings.Converters.Add(new CustomDateTimeConverter());

			return JsonConvert.SerializeObject(o, settings);
		}

		public static object ConvertValue(object Value, Type newType)
		{
			try
			{
				if (newType == typeof(byte[])) return new byte[0];

				if (Value == null) return Activator.CreateInstance(newType);

				if (Value.GetType() == newType) return Value;

				if (Nullable.GetUnderlyingType(newType) != null)
				{
					if (Value.GetType() == newType)
					{
						return Value;
					}
					return Convert.ChangeType(Value, Nullable.GetUnderlyingType(newType));
				}

				if (newType.ToString().Contains("List`1"))
				{
					Type tmp = newType.GetGenericArguments()[0];
					Type list = typeof(List<>).MakeGenericType(tmp);
					IList tmpList = Activator.CreateInstance(list) as IList;

					if (Value != null)
					{
						var tmpArr = (Value as string)
							.Split(',')
							.Select(itm => Utils.ConvertValue(itm, tmp))
							.ToArray();

						for (int x = 0; x < tmpArr.Length; x++)
						{
							tmpList.Add(tmpArr[x]);
						}
					}

					return tmpList;
				}

				return Convert.ChangeType(Value, newType);
			}
			catch
			{
			}

			return Activator.CreateInstance(newType);
		}

		public static T ConvertValue<T>(object Value)
		{
			try
			{
				if (Value == null)
				{
					return default(T);
				}

				if (Nullable.GetUnderlyingType(typeof(T)) != null)
				{
					return (T)Convert.ChangeType(Value, Nullable.GetUnderlyingType(typeof(T)));
				}

				return (T)Convert.ChangeType(Value, typeof(T));
			}
			catch
			{
			}

			return default(T);
		}

		public static byte[] GetBytes(object o)
		{
			if (o == null) return null;

			string json = Utils.ToJson(o);

			byte[] buffer = Encoding.UTF8.GetBytes(json);

			return buffer;
		}

		public static T GetObject<T>(byte[] o)
		{
			if (o == null || o.Length == 0) return default(T);

			string json = Encoding.UTF8.GetString(o);

			T ret = Utils.FromJson<T>(json);

			return ret;
		}
	}
}