using System.Collections.Generic;

namespace refactor_gym_warmup_2020.cashier
{
    public class Order
    {
        string cName;
        string addr;
        List<LineItem> lineItemList;

        public Order(string cName, string addr, List<LineItem> lineItemList)
        {
            this.cName = cName;
            this.addr = addr;
            this.lineItemList = lineItemList;
        }

        public string GetCustomerName()
        {
            return cName;
        }

        public string GetCustomerAddress()
        {
            return addr;
        }

        public List<LineItem> GetLineItems()
        {
            return lineItemList;
        }
    }
}