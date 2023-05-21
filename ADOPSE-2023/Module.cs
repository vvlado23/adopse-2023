
public class Module
{
   
    public string Price { get; set; }
   public string Difficulty { get; set; }
    public int Rating { get; set; }
    public int idModules { get; set; }
    public string moduleName { get; set; }
    public string moduleDesc { get; set; }
    public string categoryName { get; set; }

    public Module(int idModules, string moduleName, string price, int rating, string moduleDesc)
    {
        //Id = id;
        //Name = name;
        Price = price;
        //Difficulty = difficulty;
        Rating = rating;
        this.idModules = idModules;
        this.moduleName = moduleName;
        this.moduleDesc = moduleDesc;
    }

    public Module(int idModules, string moduleName, string price, int rating, string moduleDesc,string categoryName)
    {
        //Id = id;
        //Name = name;
        Price = price;
        //Difficulty = difficulty;
        Rating = rating;
        this.idModules = idModules;
        this.moduleName = moduleName;
        this.moduleDesc = moduleDesc;
        this.categoryName = categoryName;
    }
}

