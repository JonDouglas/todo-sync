using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Todo_Sync.Core.Models;

namespace Todo_Sync.API.DataContext
{
    public class TodoSyncDataContext : DbContext
    {
        public TodoSyncDataContext() : base("TodoSyncDev")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Todo> Todos { get; set; }
    }
}