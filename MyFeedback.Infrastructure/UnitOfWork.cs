﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using MyFeedback.Application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyFeedbackContext _db;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(MyFeedbackContext db)
        {
            _db = db;
        }

        void IUnitOfWork.BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            if (_db.Database.CurrentTransaction != null)
            {
                return;
            }

            _transaction = _db.Database.BeginTransaction(isolationLevel);
        }

        void IUnitOfWork.Commit()
        {
            if (_transaction == null)
            {
                throw new Exception("You must call 'BeginTransaction' before Commit is called");
            }

            _transaction.Commit();
            _transaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            if (_transaction == null)
            {
                throw new Exception("You must call 'BeginTransaction' before Rollback is called");
            }

            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
