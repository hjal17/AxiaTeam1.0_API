using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Models
{
    public class TTache

    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int status { get; set; }
        public string Name { get; set; }
        public string  Periority { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateLimite { get; set; }
        public int MyProperty { get; set; }
        public int Avancement { get; set; }
        public string TempEstimer { get; set; }

        public int UserStoryId { get; set; }
        public UserStory UserStory { get; set; }

    }
}
