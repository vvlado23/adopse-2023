using System;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using MySql.Data.MySqlClient;

namespace ADOPSE_2023
{
    public class Search
    {
        private static RAMDirectory indexDirectory; // Declare indexDirectory as a class-level field

        public static void IndexDocuments()
        {
            // Create a connection to the MySQL database
            MySqlConnection connection = DatabaseConnection.GetConnection();

            // Create a Lucene index in memory
            indexDirectory = new RAMDirectory();
            IndexWriter indexWriter = new IndexWriter(indexDirectory, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), true, IndexWriter.MaxFieldLength.UNLIMITED);

            // Fetch data from the MySQL table
            string query = "SELECT idModules, moduleName, moduleDesc FROM modules";
            
            MySqlCommand command = new MySqlCommand(query,connection);
            try
            {
                MySqlDataReader reader;
                reader = command.ExecuteReader();



                // Add data to the Lucene index
                while (reader.Read())
                {
                    Document doc = new Document();
                    doc.Add(new Field("idModules", reader["idModules"].ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    doc.Add(new Field("moduleName", reader["moduleName"].ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("moduleDesc", reader["moduleDesc"].ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    indexWriter.AddDocument(doc);
                }

                // Commit the changes to the Lucene index
                indexWriter.Commit();


                reader.Close(); // Close the reader before reusing it


                //check doc
                /*IndexReader indexReader = DirectoryReader.Open(indexDirectory,true);
                IndexSearcher indexSearcher = new IndexSearcher(indexReader);
                Query query2 = new MatchAllDocsQuery();

                // Execute the query and retrieve the search results
                TopDocs results = indexSearcher.Search(query2, int.MaxValue);

                // Process the search results
                Console.WriteLine("Check DOC:");
                foreach (ScoreDoc scoreDoc in results.ScoreDocs)
                {
                    Document doc = indexSearcher.Doc(scoreDoc.Doc);
                    // Output the contents of the document
                    Console.WriteLine("IDmodules: {0}, ModulesName: {1}, ModuleDesc: {2}", doc.Get("idModules"), doc.Get("moduleName"), doc.Get("moduleDesc"));
                } */

                reader = command.ExecuteReader(); // Re-execute the command to start from the beginning

            }catch (Exception ex) { }

            // Close the Lucene index and MySQL connection
            indexWriter.Dispose();
            connection.Close();

        }

        public static void SearchDocuments(string searchTerm,RAMDirectory indexDirectory)
        {

            Console.WriteLine("Searching...");
            // Open the Lucene index
            IndexReader indexReader = DirectoryReader.Open(indexDirectory,true);
            IndexSearcher indexSearcher = new IndexSearcher(indexReader);

            // Create a query parser
            QueryParser queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "moduleName", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));

            // Parse the search term
            Query query = queryParser.Parse(searchTerm);

            // Use Lucene to search for data
            TopDocs results = indexSearcher.Search(query, 10);

            //show Results
            Console.WriteLine("Search Results: ");
            // Process the search results
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                Document doc = indexSearcher.Doc(scoreDoc.Doc);
                Console.WriteLine("IdModules: {0}, ModuleName: {1}, ModuleDesc: {2}",
                doc.Get("idModules"), doc.Get("moduleName"), doc.Get("moduleDesc"));
            }

            // Close the Lucene index
            indexReader.Dispose();
            indexDirectory.Dispose();
        }


        public static void SearchDocumentsWild(string searchTerm, RAMDirectory indexDirectory)
        {
            Search.IndexDocuments();
            Console.WriteLine("Searching...");

            // Open the Lucene index
            IndexReader indexReader = DirectoryReader.Open(indexDirectory, true);
            IndexSearcher indexSearcher = new IndexSearcher(indexReader);

            // Create a query parser
            QueryParser queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "moduleName", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));

            // Enable leading wildcard support
            queryParser.AllowLeadingWildcard = true;

            // Create a wildcard query
            Query wildQuery = queryParser.Parse("*" + searchTerm + "*" );

            // Use Lucene to search for data
            TopDocs results = indexSearcher.Search(wildQuery, 10);

            // Show results
            Console.WriteLine("Search Results:");

            // Process the search results
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                Document doc = indexSearcher.Doc(scoreDoc.Doc);
                Console.WriteLine("IdModules: {0}, ModuleName: {1}, ModuleDesc: {2}",
                    doc.Get("idModules"), doc.Get("moduleName"), doc.Get("moduleDesc"));
            }
            // Close the Lucene index
            indexReader.Dispose();
            indexDirectory.Dispose();
        }
        public void searchTerm()
        {
            // Index documents
           

            // Search for documents
            //Search.SearchDocuments("Δια", indexDirectory);
            Console.WriteLine("Search for : _ ");
            string searchTerm = Console.ReadLine();
            Search.SearchDocumentsWild(searchTerm, indexDirectory);
        }

    }
}
