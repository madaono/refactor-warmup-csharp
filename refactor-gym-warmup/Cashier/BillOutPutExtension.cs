using System.Text;

namespace refactor_gym_warmup_2020.cashier
{
    public static class BillOutPutExtension
    {
        public static StringBuilder AppendHeader(this StringBuilder stringBuilder)
        {
            stringBuilder.Append("======Printing Orders======\n");
            return stringBuilder;
        }  
        
        public static StringBuilder AppendTotalAmount(this StringBuilder stringBuilder, double tot)
        {
            stringBuilder.Append("Total Amount")
                .Append('\t')
                .Append(tot);
            return stringBuilder;
        }
        
        public static StringBuilder AppendStateTax(this StringBuilder stringBuilder, double totSalesTx)
        {
            stringBuilder.Append("Sales Tax")
                .Append('\t')
                .Append(totSalesTx);
            return stringBuilder;
        }
        
        public static StringBuilder AppendBillContent(this StringBuilder stringBuilder, LineItem lineItem)
        {
            stringBuilder.Append(lineItem.GetDescription());
            stringBuilder.Append('\t');
            stringBuilder.Append(lineItem.GetPrice());
            stringBuilder.Append('\t');
            stringBuilder.Append(lineItem.GetQuantity());
            stringBuilder.Append('\t');
            stringBuilder.Append(lineItem.TotalAmount());
            stringBuilder.Append('\n');
            return stringBuilder;
        }
        
        public static StringBuilder AppendBillInfo(this StringBuilder stringBuilder, Order order)
        {
            stringBuilder.Append(order.GetCustomerName());
            stringBuilder.Append(order.GetCustomerAddress());
            return stringBuilder;
        }
        
    }
}