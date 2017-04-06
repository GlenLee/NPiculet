using System.Collections.Generic;
using NPiculet.Logic.Business;
using NPiculet.Logic.Data;
using NPiculet.Plugin;

namespace NPiculet.Logic.Dict
{
	public class DictManager : PluginBase, IDictModule
	{
		#region 初始化

		public DictManager(IPluginDescriptor descr) : base(descr)
		{
		}

		protected override void DoStart()
		{ }

		protected override void DoStop()
		{ }

		#endregion

		//private DictGroupBus _groupBus = new DictGroupBus();
		private readonly CmsDictItemBus _itemBus = new CmsDictItemBus();

		public DictionaryItem GetItem(string groupCode, string itemCode)
		{
			var item = _itemBus.GetDictItem(groupCode, itemCode);
			if (item != null) {
				return new DictionaryItem() {GroupCode = item.GroupCode, Code = item.Code, Name = item.Name, Value = item.Value};
			}
			return null;
		}

		public List<DictionaryItem> GetItemList(string groupCode)
		{
			var items = _itemBus.GetDictItemList(groupCode);
			if (items.Count > 0) {
				List<DictionaryItem> list = new List<DictionaryItem>();
				foreach (CmsDictItem item in items) {
					list.Add(new DictionaryItem() { GroupCode = item.GroupCode, Code = item.Code, Name = item.Name, Value = item.Value });
				}
				return list;
			}
			return new List<DictionaryItem>();
		}
	}
}