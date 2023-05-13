using System;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using MySql.Data.MySqlClient;

namespace searchEngine
{
    public class Search
    {
        public static void IndexDocuments()
        {
            // Create a connection to the MySQL database
            string connectionString = "server=dblabs.iee.ihu.gr;database=3306;uid=it185158;password=Ogma123!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // Create a Lucene index in memory
            RAMDirectory indexDirectory = new RAMDirectory();
            IndexWriter indexWriter = new IndexWriter(indexDirectory, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), true, IndexWriter.MaxFieldLength.UNLIMITED);

            // Fetch data from the MySQL table
            string query = "SELECT id, title, content FROM mytable";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            // Add data to the Lucene index
            while (reader.Read())
            {
                Document doc = new Document();
                doc.Add(new Field("id", reader["id"].ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                doc.Add(new Field("title", reader["title"].ToString(), Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field("content", reader["content"].ToString(), Field.Store.YES, Field.Index.ANALYZED));
                indexWriter.AddDocument(doc);
            }

            // Commit the changes to the Lucene index
            indexWriter.Commit();

            // Close the Lucene index and MySQL connection
            indexWriter.Dispose();
            connection.Close();
        }

        public static void SearchDocuments(string searchTerm)
        {
            // Create a Lucene index in memory
            RAMDirectory indexDirectory = new RAMDirectory();

            // Open the Lucene index
            IndexReader indexReader = DirectoryReader.Open(indexDirectory,true);
            IndexSearcher indexSearcher = new IndexSearcher(indexReader);

            // Create a query parser
            QueryParser queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "content", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));

            // Parse the search term
            Query query = queryParser.Parse(searchTerm);

            // Use Lucene to search for data
            TopDocs results = indexSearcher.Search(query, 10);

            // Process the search results
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                Document doc = indexSearcher.Doc(scoreDoc.Doc);
                Console.WriteLine("ID: {0}, Title: {1}", doc.Get("id"), doc.Get("title"));
            }

            // Close the Lucene index
            indexReader.Dispose();
            indexDirectory.Dispose();
        }



        public void searchTerm()
        {
            // Index documents
            Search.IndexDocuments();

            // Search for documents
            Search.SearchDocuments("search term");
        }

    }
}
