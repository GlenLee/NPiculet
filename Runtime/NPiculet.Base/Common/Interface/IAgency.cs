using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPiculet.Logic.Interface
{
	/// <summary>
	/// 代理接口
	/// </summary>
    public interface IAgency
    {
        int SaveAgency(string jsonAgency);

        int UpdateAgency(string jsonAgency);

        int DelAgency(string ID);

        string GetAgencyList(string condition);


    }
}
