using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using QCEL.Dtos;
using QCEL.Models;

namespace QCEL.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<SampleLocation, SampleLocationDto>();
			Mapper.CreateMap<SampleLocationDto, SampleLocation>()
				.ForMember(c => c.Id, opt => opt.Ignore());
		}
	}
}