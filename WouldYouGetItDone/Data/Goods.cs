using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WouldYouGetItDone.Data
{
    public class Goods
    {
        [Key]
        public Guid GoodsId { get; set; }
        
        public string GoodsName { get; set; }
        public double Price { get; set; }
        public byte Discount { get; set; }
        public int Qty { get; set; }
        public string Imgs { get; set; }
        
        public string Details { get; set; }
        public string Description { get; set; }
        public int? TypeId { get; set; }
        public Type Type { get; set; }
        public virtual ICollection<ReviewGoods> ReviewGoods { get; set; }
        public virtual ICollection<SubImg> SubImgs { get; set; }
        public virtual ICollection<GoodsTag> GoodsTags { get; set; }
        public double? ReviewScore { get; set; }
    }
    public class SubImg
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public Guid? GoodsId { get; set; }
        public Goods Goods { get; set; }
    }
    public class GoodsTag
    {
        public string TagKey { get; set; }
        public Guid GoodsId { get; set; }
        public Goods Goods { get; set; }
        public  Tag Tag { get; set; }
    }

    public class Tag
    {
        public virtual ICollection<GoodsTag> GoodsTags { get; set; }
        public string TagKey { get; set; }
        public string TagValue { get; set; }
    }
}

