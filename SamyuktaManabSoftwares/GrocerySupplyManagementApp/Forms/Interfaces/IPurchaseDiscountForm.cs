namespace GrocerySupplyManagementApp.Forms.Interfaces
{
    public interface IPurchaseDiscountForm
    {
        void PopulatePurchaseDiscount(string supplierId, string billNo, decimal discountAmount);
    }
}
