using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Logger
{
	/// <summary>
	/// Mirai-CSharp-Light Logger 配置
	/// </summary>
	public class MiraiCSharpLightLoggerConfig
	{
		/// <summary>
		/// 日志总开关
		/// </summary>
		public static bool Enable { get; set; } = true;

		/// <summary>
		/// 显示调试日志，需要Enable = true
		/// </summary>
		public static bool EnableLogDebug { get; set; } = false;

		/// <summary>
		/// 显示信息日志，需要Enable = true
		/// </summary>
		public static bool EnableLogInfo { get; set; } = true;

		/// <summary>
		/// 显示警告日志，需要Enable = true
		/// </summary>
		public static bool EnableLogWarning { get; set; } = true;

		/// <summary>
		/// 显示错误日志，需要Enable = true
		/// </summary>
		public static bool EnableLogError { get; set; } = true;
	}
}
