using System.Text;

namespace refactor_gym_warmup_2020.cashier
{
    /**
 * OrderReceipt prints the details of order including customer name, address, description, quantity,
 * price and amount. It also calculates the sales tax @ 10% and prints as part
 * of order. It computes the total order amount (amount of individual lineItems +
 * total sales tax) and prints it.
 *
 */
    public class OrderReceipt
    {
        private Order order;
        private double _rate = .10;
        private double _totSalesTx = 0d;
        private double _totAmount = 0d;

        public OrderReceipt(Order order)
        {
            this.order = order;
        }

        public string PrintReceipt()
        {
            StringBuilder output = new StringBuilder();

            // print headers
            // print date, bill no, customer name
            output.AppendHeader()
                .AppendBillInfo(order);

            // prints lineItems

            foreach (LineItem lineItem in order.GetLineItems())
            {
                output.AppendBillContent(lineItem);

                // calculate sales tax @ rate of 10%
                AddTotalSalesTax(lineItem);

                // calculate total amount of lineItem = price * quantity + 10 % sales tax
                AddTotalSalesAmount(lineItem);
            }

            // prints the state tax
            output.AppendStateTax(_totSalesTx);

            // print total amount
            output.AppendTotalAmount(_totAmount);
            return output.ToString();
        }

        private void AddTotalSalesTax(LineItem item)
        {
            _totSalesTx += item.TotalAmount() * _rate;
        }

        private void AddTotalSalesAmount(LineItem item)
        {
            double salesTax = item.TotalAmount() * _rate;
            _totAmount += item.TotalAmount() + salesTax;
        }
    }
}