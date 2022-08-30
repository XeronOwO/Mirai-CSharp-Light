using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 戳一戳来源信息
	/// </summary>
	public interface INudgeSubjectData : IIdData
	{
		/// <summary>
		/// 来源的类型，"Friend"或"Group"
		/// </summary>
		public ContextType Kind { get; }
	}
}
