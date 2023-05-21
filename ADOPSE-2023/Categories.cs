namespace ADOPSE_2023
{
    public class Categories
    {
        public int idCategory { get; set; }
        public string CategoryName { get; set; } 
        public int ParentCategoryID { get; set; }

        public Categories(int idCategory, string categoryName, int ParentCategoryID)
        {
            this.idCategory = idCategory;
            this.CategoryName = categoryName;
            this.ParentCategoryID = ParentCategoryID;
        }
    }
}
