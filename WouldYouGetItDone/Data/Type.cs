using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WouldYouGetItDone.Data
{
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int? GeTypeId { get; set; }
        [ForeignKey("GeTypeId")]
        public Type GeType { get; set; }
        public ICollection<Goods> Goods { get; set; }
    }
}
