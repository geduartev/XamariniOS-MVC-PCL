using System;
using NorthWind;
using PCL.SAL;
using UIKit;

namespace AppiOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ValidateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (this.Storyboard.InstantiateViewController("ValidateController") is ValidateController Controller)
                {
                    this.NavigationController.PushViewController(Controller, true);
                }
            };

            SearchButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                if (!string.IsNullOrWhiteSpace(ProductIDText.Text))
                {
                    SearchProductAsync(ProductIDText.Text);
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        async void SearchProductAsync(string ProductId)
        {
            NorthWindModel Model = new NorthWindModel();
            IProduct product = await Model.GetProductByIDAsync(Convert.ToInt32(ProductId));

            if (product != null)
            {
                ProductNameText.Text = product.ProductName;
                UnitPriceText.Text = product.UnitPrice.ToString();
                UnitsInStockText.Text = product.UnitsInStock.ToString();
                CategoryIDText.Text = product.CategoryID.ToString();
            }
        }
    }
}