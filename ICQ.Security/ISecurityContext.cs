using System;
using ICQ.Data.Models;

namespace ICQ.Security
{
    public interface ISecurityContext
    {
        User User { get; }

        bool IsAdministrator { get; }
    }
}
