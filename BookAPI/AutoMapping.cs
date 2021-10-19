using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BookAPI.DTO.BookDTO, BookAPI.Models.Book>().ReverseMap();
        }
    }
}
