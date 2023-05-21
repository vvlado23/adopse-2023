namespace ADOPSE_2023
{
    public class Categories
    {
        public int idCategory { get; set; }
        public string CategoryName { get; set; } 
        public int ParentCategoryID { get; set; }

        public Categories(int idCategory, string CategoryName, int ParentCategoryID)
        {
            this.idCategory = idCategory;
            this.CategoryName = CategoryName;
            this.ParentCategoryID = ParentCategoryID;
        }
    }
}
