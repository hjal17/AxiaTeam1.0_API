using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Models
{
    public class BackLog
    {
        public int Id { get; set; }
        public string Version  { get; set; }
        public string Description { get; set; }
        public List<UserStory> UserStory  { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
