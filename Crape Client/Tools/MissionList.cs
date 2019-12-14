using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crape_Client.Tools
{
    public class MissionList
    {
        public string Name { get; private set; }
        public string Summary { get; private set; }
        public string Spawn { get; private set; }
        public MissionList() { }
        public MissionList(string Name, string Summary, string Spawn)
        {
            this.Name = Name;
            this.Summary = Summary;
            this.Spawn = Spawn;
        }
    }
}
