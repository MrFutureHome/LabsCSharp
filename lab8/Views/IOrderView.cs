using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.Views
{
    public interface IOrderView
    {
        int OrderId { get; set; }
        string OrderClient { get; set; }
        string OrderProblem { get; set; }
        string OrderMaster { get; set; }
        void DisplayOrders(DataTable orders);
        event EventHandler AddOrder;
        event EventHandler UpdateOrder;
        event EventHandler DeleteOrder;
        event EventHandler ViewOrders;
    }
}
