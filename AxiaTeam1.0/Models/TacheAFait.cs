using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Models
{
    public class TacheAFait
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int tacheId { get; set; }
        public TTache tache { get; set; }
    }
}
