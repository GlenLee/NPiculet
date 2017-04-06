using System.Collections.Generic;
using NPiculet.Plugin;

namespace NPiculet.Logic.Dict
{
	public interface IDictModule : IPlugin
	{
		DictionaryItem GetItem(string groupCode, string itemCode);

		List<DictionaryItem> GetItemList(string groupCode);
	}
}