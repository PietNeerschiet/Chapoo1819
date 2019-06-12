using ChapooModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapoo1819 {
    class ViewOrders {
        private static ViewOrders uniqueInstance;

        private List<OrderItem> orderItems = new List<OrderItem>();
        private List<OrderItem> sortedItems = new List<OrderItem>();
        public List<OrderItem> changedSortedItems = new List<OrderItem>();
        private List<OrderItem> deletedOIs = new List<OrderItem>();
        private Dictionary<OrderItem, int> changedOIs = new Dictionary<OrderItem, int>();

        private ViewOrders(List<OrderItem> orderItems) {
            this.orderItems = orderItems;
        }

        public static ViewOrders MakeInstances(List<OrderItem> orderItems) {
            return uniqueInstance = new ViewOrders(orderItems);
        }

        public static ViewOrders GetInstances() {
            return uniqueInstance;
        }

        public List<OrderItem> GetSortedItems() {
            foreach (OrderItem x in orderItems) {
                if (sortedItems.Count == 0) {
                    sortedItems.Add(x);
                } else {
                    if (sortedItems.Exists((OrderItem item) => { return item.MenuProduct.MenuItemCode == x.MenuProduct.MenuItemCode && (item.Comment == null && x.Comment == null); })) {
                        OrderItem y = sortedItems.Find((OrderItem item) => { return item.MenuProduct.MenuItemCode == x.MenuProduct.MenuItemCode && (item.Comment == null && x.Comment == null); });
                        y.Quantity += x.Quantity;
                    } else {
                        sortedItems.Add(x);
                    }
                }
            }

            changedSortedItems = sortedItems;

            return sortedItems;
        }

        public void AddQuantity(OrderItem i) {

            changedSortedItems.Find((OrderItem item) => {
                return item.MenuProduct.MenuItemCode == i.MenuProduct.MenuItemCode && ((item.Comment == null && i.Comment == null) || item.Comment == i.Comment);
            }).Quantity++;

            if (changedOIs.Keys.Contains(i)) {
                if (changedOIs[i]++ == 0) {
                    changedOIs.Remove(i);
                } else {
                    changedOIs[i]++;
                }
            } else {
                changedOIs.Add(i, 1);
            }
        }

        public void MinusQuantity(OrderItem i) {
            OrderItem orderItem = changedSortedItems.Find((OrderItem item) => {
                return item.MenuProduct.MenuItemCode == i.MenuProduct.MenuItemCode && ((item.Comment == null && i.Comment == null) || item.Comment == i.Comment);
            });

            orderItem.Quantity--;

            if (orderItem.Quantity == 0) {
                deletedOIs.Add(i);
                changedOIs.Remove(i);
                return;
            }

            if (changedOIs.Keys.Contains(i)) {
                if (changedOIs[i]-- == 0) {
                    changedOIs.Remove(i);
                } else {
                    changedOIs[i]--;
                }
            } else {
                changedOIs.Add(i, -1);
            }
        }

        public void Delete(OrderItem i) {
            changedSortedItems.Remove(changedSortedItems.Find((OrderItem item) => {
                return item.MenuProduct.MenuItemCode == i.MenuProduct.MenuItemCode && ((item.Comment == null && i.Comment == null) || item.Comment == i.Comment);
            }));

            deletedOIs.Add(i);
        }

        public List<OrderItem> ConfirmChanges() {
            List<OrderItem> changedOrderItems = new List<OrderItem>();
            int i = 0;

            foreach (OrderItem item in changedOIs.Keys) {
                i = changedOIs[item];
                foreach (OrderItem sub in orderItems) {
                    if (item.MenuProduct.MenuItemCode == sub.MenuProduct.MenuItemCode && ((item.Comment == null && sub.Comment == null) || item.Comment == sub.Comment)) {
                        if (sub.Quantity + i < 0) {
                            i = sub.Quantity + i;
                            sub.Quantity = 0;
                            changedOrderItems.Add(sub);
                        } else {
                            changedOrderItems.Add(sub);
                        }
                    }
                }
            }

            foreach (OrderItem item in deletedOIs) {
                foreach (OrderItem sub in orderItems) {
                    if (item.MenuProduct.MenuItemCode == sub.MenuProduct.MenuItemCode && ((item.Comment == null && sub.Comment == null) || item.Comment == sub.Comment)) {
                        sub.Quantity = 0;
                        changedOrderItems.Add(sub);
                    }
                }
            }

            return changedOrderItems;
        }
    }
}
