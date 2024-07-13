using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Common
{
    public abstract class BaseEntity<TKey> : IHasKey<TKey>
    {
        [Key]
        public required TKey Id { get; set; }
    }
}
