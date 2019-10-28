using Microsoft.AspNetCore.Mvc.Filters;

namespace ICQ.Helpers
{
    public interface IActionTransactionHelper
    {
        void BeginTransaction();
        void EndTransaction(ActionExecutedContext filterContext);
        void CloseSession();
    }
}