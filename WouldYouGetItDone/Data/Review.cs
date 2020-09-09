using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WouldYouGetItDone.Data
{
    public class Review
    {
        public int Id { get; set; }
        public string Criteria { get; set; }
        public bool Active { get; set; }
        public ICollection<ReviewGoods> ReviewGood { get; set; }
    }
    public class ReviewGoods
    {
        public Guid Id { get; set; }
        public DateTime ReviewDay { get; set; }
        public byte ReviewScore { get; set; }
        public int Criteria { get; set; }
        public Guid GoodsId { get; set; }
        [ForeignKey("Criteria")]
        public Review Review { get; set; }
        [ForeignKey("GoodsId")]
        public Goods Goods { get; set; }
    }
}