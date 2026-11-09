using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Terraria.Social.WeGame;

public class WeGameHelper
{
	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	private static extern void OutputDebugString(string message);

	public static void WriteDebugString(string format, params object[] args)
	{
		_ = "[WeGame] - " + format;
	}

	public static string Serialize<T>(T data)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		DataContractJsonSerializer val = new DataContractJsonSerializer(typeof(T));
		using MemoryStream memoryStream = new MemoryStream();
		((XmlObjectSerializer)val).WriteObject((Stream)memoryStream, (object)data);
		memoryStream.Position = 0L;
		using StreamReader streamReader = new StreamReader(memoryStream, Encoding.UTF8);
		return streamReader.ReadToEnd();
	}

	public static void UnSerialize<T>(string str, out T data)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		using MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(str));
		DataContractJsonSerializer val = new DataContractJsonSerializer(typeof(T));
		data = (T)((XmlObjectSerializer)val).ReadObject((Stream)memoryStream);
	}
}
