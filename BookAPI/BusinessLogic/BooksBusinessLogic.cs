using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace BookAPI.BusinessLogic
{
    public class BooksBusinessLogic
    {
        private readonly IConfiguration _configuration;

        public BooksBusinessLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<DTO.BookDTO> GetBooks()
        {
            List<DTO.BookDTO> lstBooks = null;

            using (SqlDataReader reader = DataBase.Book.GetBooks())
            {
                if (!reader.HasRows) return null;

                lstBooks = new List<DTO.BookDTO>();

                while (reader.Read())
                {
                    lstBooks.Add(new DTO.BookDTO
                    {
                        BookAuthor = reader["bookAuthorName"].ToString(),
                        BookID = Convert.ToInt32(reader["bookId"]),
                        BookName = reader["bookName"].ToString(),
                        BookAddedOn = Convert.ToDateTime(reader["DateAdded"])
                    });
                }
            }

            return lstBooks;
        }

        public DTO.BookDTO GetBook(int bookId)
        {
            DTO.BookDTO book = null;

            using (SqlDataReader reader = DataBase.Book.GetBook(bookId))
            {
                if (!reader.HasRows) return null;

                book = new DTO.BookDTO();

                reader.Read();

                book = new DTO.BookDTO
                {
                    BookAuthor = reader["bookAuthorName"].ToString(),
                    BookID = Convert.ToInt32(reader["bookId"]),
                    BookName = reader["bookName"].ToString(),
                    BookAddedOn = Convert.ToDateTime(reader["DateAdded"])
                };

            }

            return book;
        }

        public void AddBook(DTO.BookDTO newBook)
        {
            DataBase.Book.AddBook(newBook.BookName, newBook.BookAuthor);
        }

        public void UpdateBook(DTO.BookDTO newBook)
        {
            DataBase.Book.UpdateBook(newBook.BookID, newBook.BookName, newBook.BookAuthor);
        }

        public void DeleteBook(int bookId)
        {
            DataBase.Book.DeleteBook(bookId);
        }

    }
}
