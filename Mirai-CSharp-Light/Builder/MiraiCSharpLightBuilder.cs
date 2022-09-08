using Mirai.CSharp.Light.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Builder
{
	/// <summary>
	/// 用于更方便快捷地构建MiraiCSharpLight
	/// </summary>
	public class MiraiCSharpLightBuilder
	{
		private readonly MiraiCSharpLight session = new();

		/// <summary>
		/// 设置验证密钥，须与Mirai-Api-Http的verifyKey相同。<br/>
		/// 详见：<see href="https://github.com/project-mirai/mirai-api-http">Mirai-Api-Http</see>
		/// </summary>
		/// <param name="verifyKey"></param>
		/// <returns>MiraiCSharpLightBuilder实例</returns>
		public MiraiCSharpLightBuilder SetVerifyKey(string verifyKey)
		{
			session.VerifyKey = verifyKey;
			return this;
		}

		/// <summary>
		/// 设置Session将要绑定的Bot的qq号。<br/>
		/// </summary>
		/// <param name="qq">Session将要绑定的Bot的qq号</param>
		/// <returns>MiraiCSharpLightBuilder实例</returns>
		public MiraiCSharpLightBuilder SetQQ(long qq)
		{
			session.QQ = qq;
			return this;
		}

		/// <inheritdoc cref="MiraiCSharpLight.AddHandler(object)"/>
		public MiraiCSharpLightBuilder AddHandler(object handler)
		{
			session.AddHandler(handler);
			return this;
		}

		/// <inheritdoc cref="MiraiCSharpLight.Connect(string)"/>
		public MiraiCSharpLight Connect(string url)
		{
			session.Connect(url);
			return session;
		}

		/// <inheritdoc cref="MiraiCSharpLight.ConnectAsync(string)"/>
		public Task<MiraiCSharpLight> ConnectAsync(string url) => Task.Run(() => Connect(url));

		/// <summary>
		/// 隐式转换成MiraiCSharpLight
		/// </summary>
		/// <param name="builder">MiraiBuilde实例</param>
		public static implicit operator MiraiCSharpLight(MiraiCSharpLightBuilder builder) => builder.session;
	}
}
