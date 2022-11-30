namespace WEEK7APIFINALSOULTION.Model
{
    public abstract class Pagination
    {
        public int page { get; set; } = 1;

        private int itemsPerPage;
        private int _maxItemsPage = 50;
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value > _maxItemsPage ? _maxItemsPage : value; }
        }
    }
}
