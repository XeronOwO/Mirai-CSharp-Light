using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 戳一戳事件信息
	/// </summary>
	public interface INudgeEventData
	{
		/// <summary>
		/// 事件类型
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// 动作发出者的QQ号
		/// </summary>
		public long FromId { get; }

		/// <summary>
		/// 来源
		/// </summary>
		public INudgeSubjectData Subject { get; }

		/// <summary>
		/// 动作类型
		/// </summary>
		public string Action { get; }

		/// <summary>
		/// 自定义动作内容
		/// </summary>
		public string Suffix { get; }

		/// <summary>
		/// 动作目标的QQ号
		/// </summary>
		public long Target { get; }
	}
}
