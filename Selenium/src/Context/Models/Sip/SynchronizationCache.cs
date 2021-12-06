using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(SynchronizationCache), Schema = Schemas.Sip)]
    public partial class SynchronizationCache
    {
        [Key]
        public long SynchronizationCacheId { get; set; }

        public byte Action { get; set; }

        public bool HasError { get; set; }

        public string ItemId { get; set; }

        public string ServerName { get; set; }

        public byte TableName { get; set; }

        public DateTime Time { get; set; }
    }
}