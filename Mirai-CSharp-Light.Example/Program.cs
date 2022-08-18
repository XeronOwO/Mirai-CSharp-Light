using Mirai.CSharp.Light.Builder;
using Mirai.CSharp.Light.Handler;
using Mirai.CSharp.Light.Models.EventArgs;
using Mirai.CSharp.Light.Models.Message;
using Mirai.CSharp.Light.Session;
using Mirai_CSharp_Light.Example;

namespace Mirai.CSharp.Light.Example
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var mirai = new MiraiCSharpLightBuilder().SetVerifyKey("Xeron_owo")
													 .SetQQ(2787174629L)
													 .AddHandler(new ExampleGroupMessageHandler())
													 .AddHandler(new ExampleFriendMessageHandler())
													 .Connect("http://1.117.59.28:6666");

			Console.ReadKey();
			var id = mirai.MiraiSession.SendTempMessage(2398003522L, 213817613L, new IChatMessage[] { new PlainMessage("测试") });
			var e = mirai.MiraiSession.GetMessage(id);
			Console.ReadKey();
			mirai.Release();
		}
	}
}