using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public partial class Database : DbContext
    {
        public Database()
            : base("DefaultConnection")
        {
        }

        public void MarkAsAdded(object entity)
        {
            SetEntityState(entity, EntityState.Added);
        }

        public virtual void MarkAsDeleted(object entity)
        {
            SetEntityState(entity, EntityState.Deleted);
        }

        public void SetEntityState(object entity, EntityState value)
        {
            this.Entry(entity).State = value;
        }

    }
}
