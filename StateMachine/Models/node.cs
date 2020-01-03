using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateMachine.Models
{
    public class node
    { 
        public string id { get; set; }
        public int top { get; set; }
        public int left { get; set; }
    }
}


/**
 {"nodes":[{"id":"\n","top":102,"left":332},
          {"id":"=","top":269,"left":250},
          {"id":")","top":288,"left":528}],
 "connections":[{"uuids":["\n_bottom","=_top"]},
                {"uuids":["\n_bottom",")_top"]}]
 }
  
 **/
