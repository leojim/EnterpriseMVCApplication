﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Transactions;

namespace GroceryApp.Models.Services
{
    public class DropCreateDatabaseTables : IDatabaseInitializer<GroceryDbContext>
{
#region IDatabaseInitializer<Context> Members

    public void InitializeDatabase(GroceryDbContext context)
    {
        bool dbExists;
        using (new TransactionScope(TransactionScopeOption.Suppress))
        {
            dbExists = context.Database.Exists();
        }
        if (dbExists)
        {
            // remove all tables
            context.Database.ExecuteSqlCommand(
               "EXEC sp_MSforeachtable @command1 = \"DROP TABLE ?\"");

            // create all tables
            var dbCreationScript = ((IObjectContextAdapter)
                   context).ObjectContext.CreateDatabaseScript();
            context.Database.ExecuteSqlCommand(dbCreationScript);
            
            Seed(context);
            context.SaveChanges();
        }
        else
        {
            throw new ApplicationException("No database instance");
        }
    }

#endregion

#region Methods

    protected virtual void Seed(GroceryDbContext context)
    {
        /// TODO: put here your seed creation
    }

#endregion
}
}