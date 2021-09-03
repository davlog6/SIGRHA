using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientsDomain
{
    public class ClientModel
    {
        [Key]
        public int IdClient { get; set; }
        public string Name { get; set; }        
    }

}
