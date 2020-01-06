using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateMachine.Models
{
    public class WorkflowModel
    { 
        public int WorkflowId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string JSON { get; set; }

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
