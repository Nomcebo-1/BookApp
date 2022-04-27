using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class BookDataAccessLayer
    {
        string connectionString = "Data Source=SIBONGILENN\\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True";

       

        public IEnumerable<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getAllBooks", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Book book = new Book();

                    book.BookId = Convert.ToInt32(rdr["BookId"]);
                    book.Title = rdr["Title"].ToString();
                    book.Author = rdr["Author"].ToString();
                    book.Category = rdr["Category"].ToString();

                    books.Add(book);

                }
                connection.Close();

            }
            return books;
        }


    }
}
