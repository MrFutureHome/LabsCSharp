using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab8.Models;
using lab8.Views;
using System.Threading.Tasks;

namespace lab8.Presenters
{
    public class OrderPresenter
    {
        private readonly IOrderView view;
        private readonly OrderModel model;

        public OrderPresenter(IOrderView view, OrderModel model)
        {
            this.view = view;
            this.model = model;

            view.AddOrder += OnAddOrder;
            view.UpdateOrder+= OnUpdateOrder;
            view.DeleteOrder += OnDeleteOrder;
            view.ViewOrders += OnViewOrders;
        }

        private void OnAddOrder(Object sender, EventArgs e)
        {
            model.CreateOrder(view.OrderClient, view.OrderProblem, view.OrderMaster);
            OnViewOrders(sender, e);
        }

        private void OnUpdateOrder(Object sender, EventArgs e)
        {
            model.UpdateOrder(view.OrderId, view.OrderClient, view.OrderProblem, view.OrderMaster);
            OnViewOrders(sender, e);
        }

        private void OnDeleteOrder(Object sender, EventArgs e)
        {
            model.DeleteOrder(view.OrderId);
            OnViewOrders(sender, e);
        }

        private void OnViewOrders(Object sender, EventArgs e)
        {
            view.DisplayOrders(model.RefreshOrders());
        }
    }
}
