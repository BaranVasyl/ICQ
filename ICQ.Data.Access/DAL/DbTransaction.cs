﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

namespace ICQ.Data.Access.DAL
{
    public class DbTransaction : ITransaction
    {
        private readonly IDbContextTransaction _efTransaction;

        public DbTransaction(IDbContextTransaction efTransaction)
        {
            _efTransaction = efTransaction;
        }

        public void Commit()
        {
            _efTransaction.Commit();
        }

        public void Rollback()
        {
            _efTransaction.Rollback();
        }

        public void Dispose()
        {
            _efTransaction.Dispose();
        }
    }
}
