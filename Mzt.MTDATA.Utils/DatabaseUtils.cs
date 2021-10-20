using System;
using System.Transactions;

namespace Mzt.MTDATA.Utils
{
    public static class DatabaseUtils
    {
        public static void InReadUncommitedScope(Action doWork)
        {
            using (new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                doWork();
            }
        }
        public static T InReadUncommitedScope<T>(Func<T> func)
        {
            using (new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                return func();
            }
        }

        public static void InTransaction(Action doWork)
        {
            using (var transaction = new TransactionScope())
            {
                doWork();
                transaction.Complete();
            }
        }

        public static T InTransaction<T>(Func<T> doWork)
        {
            using (var transaction = new TransactionScope())
            {
                return doWork();
            }
        }
    }
}
