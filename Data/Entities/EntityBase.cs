using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
