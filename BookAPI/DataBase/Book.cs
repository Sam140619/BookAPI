using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.DataBase
{
    public class Book
    {
        public static SqlDataReader GetBooks()
        {
            SqlConnection conn = Connection.GetConnection();

            using (SqlCommand command = new SqlCommand("sp_GetBooks", conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                return command.ExecuteReader();
            }
        }

        public static SqlDataReader GetBook(int BookID)
        {
            SqlConnection conn = Connection.GetConnection();

            using (SqlCommand command = new SqlCommand("sp_GetBookByID", conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@bookId", BookID);

                return command.ExecuteReader();
            }
        }

        public static void AddBook(string bookName, string authorName)
        {
            SqlConnection conn = Connection.GetConnection();

            using (SqlCommand command = new SqlCommand("sp_AddBook", conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@bookName", bookName);
                command.Parameters.AddWithValue("@bookAuthor", authorName);

                command.ExecuteNonQuery();
            }
        }
        public static void UpdateBook(int bookId,string bookName,string authorName)
        {
            SqlConnection conn = Connection.GetConnection();

            using (SqlCommand command = new SqlCommand("sp_UpdateBook", conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@bookId", bookId);
                command.Parameters.AddWithValue("@bookName", bookName);
                command.Parameters.AddWithValue("@bookAuthor", authorName);

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteBook(int bookId)
        {
            SqlConnection conn = Connection.GetConnection();

            using (SqlCommand command = new SqlCommand("sp_DeleteBook", conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@bookId", bookId);

                command.ExecuteNonQuery();
            }
        }
    }
}
