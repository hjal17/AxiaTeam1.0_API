using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateLimite { get; set; }
        public string TempEstimer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
