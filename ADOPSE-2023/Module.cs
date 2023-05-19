
    public class Module
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string Difficulty { get; set; }
            public int Rating { get; set; }

            public Module(int id, string name, string price, string difficulty, int rating)
            {
                Id = id;
                Name = name;
                Price = price;
                Difficulty = difficulty;
                Rating = rating;
            }
        }
    
