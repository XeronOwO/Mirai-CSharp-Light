using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Logger
{
	internal class MiraiCSharpLightLogger
	{
		private string? name;

		public void Log(LogType type, string text)
		{
			if (type == LogType.Debug && !MiraiCSharpLightLoggerConfig.EnableLogDebug) return;
			if (type == LogType.Info && !MiraiCSharpLightLoggerConfig.EnableLogInfo) return;
			if (type == LogType.Warning && !MiraiCSharpLightLoggerConfig.EnableLogWarning) return;
			if (type == LogType.Error && !MiraiCSharpLightLoggerConfig.EnableLogError) return;
			var tmp = Console.ForegroundColor;
			var sb = new StringBuilder();
			sb.Append(DateTime.Now.ToString("[yy:MM:dd] [HH:mm:ss] "));
			switch (type)
			{
				case LogType.Debug:
					sb.Append("[调试]");
					Console.ForegroundColor = ConsoleColor.White;
					break;
				case LogType.Info:
					sb.Append("[信息]");
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case LogType.Warning:
					sb.Append("[警告]");
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case LogType.Error:
					sb.Append("[错误]");
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				default:
					throw new System.Exception("未知日志类型");
			}
			sb.Append(" ");
			if (name != null)
			{
				sb.Append("[");
				sb.Append(name);
				sb.Append("] ");
			}
			sb.Append(text);
			Console.WriteLine(sb.ToString());
			Console.ForegroundColor = tmp;
		}

		public void Debug(string text) => Log(LogType.Debug, text);

		public void Info(string text) => Log(LogType.Info, text);

		public void Warning(string text) => Log(LogType.Warning, text);

		public void Error(string text) => Log(LogType.Error, text);

		public static MiraiCSharpLightLogger GetLogger()
		{
			return new MiraiCSharpLightLogger();
		}

		public static MiraiCSharpLightLogger GetLogger(string name)
		{
			return new MiraiCSharpLightLogger()
			{
				name = name,
			};
		}
	}
}
