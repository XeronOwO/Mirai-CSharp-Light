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
			var mirai = new MiraiCSharpLightBuilder().SetVerifyKey("VerifyKey")
													 .SetQQ(2787174629L)
													 .AddHandler(new ExampleGroupMessageHandler())
													 .AddHandler(new ExampleFriendMessageHandler())
													 .Connect("http://127.0.0.1:12345");
			Console.ReadKey();
			mirai.Release();
		}
	}
}