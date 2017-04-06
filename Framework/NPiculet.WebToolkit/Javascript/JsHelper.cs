using System.Collections.Generic;

namespace NPiculet.WebToolkit.Javascript
{
	public class JsHelper
	{
		private Dictionary<JsScript, string> dictionary = new Dictionary<JsScript, string>()
		{
			{ JsScript.GoHistory, "window.history.go(-1);" },
			{ JsScript.Alert, "alert('{0}');" },
		};

		public string GetScript(JsScript script)
		{
			return dictionary.ContainsKey(script) ? dictionary[script] : "";
		}
	}
}