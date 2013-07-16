using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSiteModel
{
	public class TestSerializerModel
	{
		public string StringVal { get; set; }

		public int IntVal { get; set; }

		public DateTime DtValue { get; set; }

		public decimal Money { get; set; }

		public Guid Guid { get; set; }


		public override string ToString()
		{
			return string.Format("StringVal: {0}; IntVal: {1}; DtValue: {2}; Money: {3}; Guid: {4}",
				this.StringVal, this.IntVal, this.DtValue.ToString("yyyy-MM-dd HH:mm:ss"), this.Money, this.Guid);
		}


		public static TestSerializerModel Create(string stringVal, int intVal, DateTime dtValue, decimal money, Guid guid)
		{
			return new TestSerializerModel {
				StringVal = stringVal,
				IntVal = intVal,
				DtValue = dtValue,
				Money = money,
				Guid = guid
			};
		}
	}



	public class TestSerializerModel2
	{
		public string StringVal { get; set; }

		public int? IntVal { get; set; }

		public DateTime? DtValue { get; set; }

		public decimal? Money { get; set; }

		public Guid? Guid { get; set; }


		public override string ToString()
		{
			return string.Format("StringVal: {0}; IntVal: {1}; DtValue: {2}; Money: {3}; Guid: {4}",
				(this.StringVal == null ? "null" : this.StringVal),
				(this.IntVal.HasValue ? this.IntVal.Value.ToString() : "null"),
				(this.DtValue.HasValue ? this.DtValue.Value.ToString("yyyy-MM-dd HH:mm:ss") : "null"), 
				(this.Money.HasValue ? this.Money.Value.ToString() : "null"),
				(this.Guid.HasValue ? this.Guid.Value.ToString() : "null")
				);
		}


		public static TestSerializerModel2 Create(string stringVal, int? intVal, DateTime? dtValue, decimal? money, Guid? guid)
		{
			return new TestSerializerModel2 {
				StringVal = stringVal,
				IntVal = intVal,
				DtValue = dtValue,
				Money = money,
				Guid = guid
			};
		}
	}



	public class TestSerializerModel3
	{
		public string StringVal { get; set; }

		public Category Category { get; set; }

		public Product Product { get; set; }

		public Customer Customer { get; set; }
	}
}
