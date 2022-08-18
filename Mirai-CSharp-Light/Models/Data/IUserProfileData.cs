using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirai.CSharp.Light.Models.Data
{
	/// <summary>
	/// 个人资料信息
	/// </summary>
	public interface IUserProfileData
	{
		/// <summary>
		/// 昵称
		/// </summary>
		public string Nickname { get; }
		
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email { get; }

		/// <summary>
		/// 年龄
		/// </summary>
		public int Age { get; }

		/// <summary>
		/// 等级
		/// </summary>
		public int Level { get; }
		
		/// <summary>
		/// 个人签名
		/// </summary>
		public string Sign { get; }

		/// <summary>
		/// 性别
		/// </summary>
		public Sex Sex { get; }
	}
}
