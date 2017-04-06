using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPiculet.Plugin;

namespace NPiculet.Logic.Info
{
    public class NoticeDescriptor : IPluginDescriptor
    {
        public string GetId()
        {
            return "NoticeModule";
        }

        public Type GetPluginType()
        {
            return typeof(NoticeManager);
        }

        public Type[] GetDependPlugins()
        {
            return new Type[0];
        }

        public string GetResourceString(string key)
        {
            return null;
        }

        public string GetPluginPath()
        {
            return null;
        }

    }
}
