using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 上传内容的类别
	/// </summary>
	public enum UploadType
	{
		/// <summary>
		/// 好友
		/// </summary>
		Friend,
		/// <summary>
		/// 群聊
		/// </summary>
		Group,
		/// <summary>
		/// 临时
		/// </summary>
		Temp,
	}
}
