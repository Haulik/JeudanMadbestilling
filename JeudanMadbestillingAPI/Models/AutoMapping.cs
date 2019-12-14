using System;
using JeudanMadbestilling.Models.ViewModels;
using AutoMapper;

namespace JeudanMadbestillingAPI.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<JeudanMadbestilling.Models.Madbestillings, MadbestillingVM>();
        }
    }
}
