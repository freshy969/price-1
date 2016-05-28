using Model.GoogleChart;

namespace BusinessLogic.ServiceInterfaces
{
    public interface IPricePointService
    {
        DataTable GetItemPricesForYears(string itemCode, int fromYear, int toYear);
    }
}
