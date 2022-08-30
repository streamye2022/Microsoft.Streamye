using Microsoft.Extensions.Configuration;
using Microsoft.Streamye.DesignPrinciples.DependencyInverse;
using Microsoft.Streamye.DesignPrinciples.OpenClose;

namespace Microsoft.Streamye.DesignPrinciples.DemeteRule
{
    public class EBusiness
    {
        private Order _order = new Order();
        private Pay _pay = new Pay();
        private Product _product = new Product();
        private Stock _stock = new Stock();

        private AliPay _aliPay = new AliPay();
        private WXPay _wxPay = new WXPay();
        private MSPay _msPay = new MSPay();
        // 问题：applePay??  1.如果要换pay的方式，代码要变 =》 抽象接口  2.继续：如果我这儿也不想动，因为不符合开闭原则
        private IPay _ipay = new AliPay();
        
        private PayFactory _payFactory;
        public EBusiness(PayFactory payFactory)
        {
            _payFactory = payFactory;
        }
        
        public void BuyGoods(string payType)
        // public void BuyGoods()
        {
            _product.ChooseProduct();
            
            _order.CreateOrder();
            
            _stock.SubStock();
            
            // _ipay.CreatePay();
            
            // _aliPay.CreatePay();
            // _wxPay.CreatePay();
            // _msPay.CreatePay();

            //_payFactory.GetPay("WX");

            _payFactory.GetPay(payType).CreatePay();
        }
    }
}