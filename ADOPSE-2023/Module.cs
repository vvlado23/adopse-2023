
public class Module
{
   // public int Id { get; set; }
   // public string Name { get; set; }
    public string Price { get; set; }
     public int Difficulty { get; set; }
    public int Rating { get; set; }
    public int idModules { get; set; }
    public string moduleName { get; set; }
    public string moduleDesc { get; set; }
    public string categoryName { get; set; }

    public Module(int idModules, string moduleName, string price, int rating,int difficulty, string moduleDesc)
    {
        
        Price = price;
        Difficulty = difficulty;
        Rating = rating;
        this.idModules = idModules;
        this.moduleName = moduleName;
        this.moduleDesc = moduleDesc;
    }
    public Module(int idModules, string moduleName, string price, int rating, int difficulty, string moduleDesc,string categoryName)
    {

        Price = price;
        Difficulty = difficulty;
        Rating = rating;
        this.idModules = idModules;
        this.moduleName = moduleName;
        this.moduleDesc = moduleDesc;
        this.categoryName = categoryName;
    }

}

