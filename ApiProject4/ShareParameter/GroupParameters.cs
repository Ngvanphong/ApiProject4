using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject4.ShareParameter
{
  public  class GroupParameters
    {
        public string Group { get; set; }

        public int Id { set; get; }

        public List<Guid> IdParameter { set; get; }

        public List<String> NameParameter { set; get; }

        public GroupParameters()
        {
            IdParameter = new List<Guid>();
            NameParameter = new List<string>();
        }
    }
    public class OldNewGroup
    {
        public string OldName { set; get; }
        public string NewName { set; get; }
    }
}
