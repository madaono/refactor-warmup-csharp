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

        public OrderReceipt(Order order)
        {
            this.order = order;
        }

        public string PrintReceipt()
        {
            StringBuilder output = new StringBuilder();

            // print headers
            AppendHeaders(output);

            // print date, bill no, customer name
//        output.Append("Date - " + order.getDate();
            AppendBillInfo(output);
//        output.Append(order.getCustomerLoyaltyNumber());

            // prints lineItems

            double totSalesTx = 0d;

            double tot = 0d;

            foreach (LineItem lineItem in order.GetLineItems())
            {
                AppendBillContent(output, lineItem);

                // calculate sales tax @ rate of 10%
                double salesTax = lineItem.TotalAmount() * _rate;
                totSalesTx += salesTax;

                // calculate total amount of lineItem = price * quantity + 10 % sales tax
                tot += lineItem.TotalAmount() + salesTax;
            }

            // prints the state tax
            AppendStateTax(output, totSalesTx);

            // print total amount
            AppendTotalAmount(output, tot);
            return output.ToString();
        }

        private static void AppendTotalAmount(StringBuilder output, double tot)
        {
            output.Append("Total Amount")
                .Append('\t')
                .Append(tot);
        }

        private static void AppendStateTax(StringBuilder output, double totSalesTx)
        {
            output.Append("Sales Tax")
                .Append('\t')
                .Append(totSalesTx);
        }

        private static void AppendBillContent(StringBuilder output, LineItem lineItem)
        {
            output.Append(lineItem.GetDescription());
            output.Append('\t');
            output.Append(lineItem.GetPrice());
            output.Append('\t');
            output.Append(lineItem.GetQuantity());
            output.Append('\t');
            output.Append(lineItem.TotalAmount());
            output.Append('\n');
        }

        private void AppendBillInfo(StringBuilder output)
        {
            output.Append(order.GetCustomerName());
            output.Append(order.GetCustomerAddress());
        }

        private static StringBuilder AppendHeaders(StringBuilder output)
        {
            return output.Append("======Printing Orders======\n");
        }
    }
}