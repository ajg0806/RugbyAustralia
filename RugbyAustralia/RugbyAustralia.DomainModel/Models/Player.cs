using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RugbyAustralia.DomainModel.Models
{
    public class Player
    {
        [Key]
        public string Player_Mid {get; set;}
        public string Player_Name {get; set;}
    }
}
