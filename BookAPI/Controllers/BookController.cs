using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.Data.SqlClient;

namespace BookAPI.Controllers
{
    //api/
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly BusinessLogic.BooksBusinessLogic booksBusinessLogic;
        public BookController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            booksBusinessLogic = new BusinessLogic.BooksBusinessLogic(_configuration);
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var booksDTO = booksBusinessLogic.GetBooks();

                return Ok(_mapper.Map<List<Models.Book>>(booksDTO));
            }
            catch (SqlException sqlEx)
            {
                return StatusCode(500, sqlEx.Message);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{bookId}")]
        public IActionResult Get(int bookId)
        {

            try
            {
                var booksDTO = booksBusinessLogic.GetBook(bookId);

                if (booksDTO is null)
                {
                    return NotFound();
                }

                var books = _mapper.Map<Models.Book>(booksDTO);

                return Ok(books);
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }

        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.Book bookDetails)
        {

            try
            {
                var newBook = _mapper.Map<DTO.BookDTO>(bookDetails);

                booksBusinessLogic.AddBook(newBook);

                return Ok();
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Models.Book bookDetails)
        {
            try
            {
                if (bookDetails == null)
                {
                    return BadRequest();
                }

                var booksDTO = booksBusinessLogic.GetBook(bookDetails.BookID);

                if (booksDTO == null)
                    return NotFound();

                var newBook = _mapper.Map<DTO.BookDTO>(bookDetails);

                booksBusinessLogic.UpdateBook(newBook);

                return Ok();
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            try
            {
                if (bookId == 0)
                {
                    return BadRequest();
                }

                var booksDTO = booksBusinessLogic.GetBook(bookId);

                if (booksDTO == null)
                    return NotFound();

                booksBusinessLogic.DeleteBook(bookId);

                return NoContent();
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }
        }
    }
}
