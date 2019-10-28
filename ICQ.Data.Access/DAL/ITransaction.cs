using System;
using System.Collections.Generic;
using System.Text;

namespace ICQ.Data.Access.DAL
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
