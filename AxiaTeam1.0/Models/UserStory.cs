using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Models
{
    public class UserStory

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string TemEstimer { get; set; }

        public int BackLogId { get; set; }

        public BackLog BackLog { get; set; }

        public List<TTache> Taches { get; set; }
    }
}
