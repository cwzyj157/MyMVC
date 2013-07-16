using WebSiteCommonLib;

namespace WebSiteModel
{
	/// <summary>
	/// 所有数据实体的基类
	/// </summary>
	public abstract class MyDataItem
	{
		public virtual string IsValid()
		{
			return null;
		}

		public virtual void EnsureItemIsOK()
		{
			string error = this.IsValid();
			if( string.IsNullOrEmpty(error) == false )
				throw new MyMessageException(error);
		}


	}
}



