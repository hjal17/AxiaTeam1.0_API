using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Dtos
{
    public class AdminStatDto
    {
        public int users  { get; set; }
        public int projects { get; set; }
        public int finishedProjects { get; set; }
        public int teams { get; set; }
        public int clients { get; set; }
    }
}
