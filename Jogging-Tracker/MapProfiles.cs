using AutoMapper;
using Jogging_Tracker.DTOs.Account;
using Jogging_Tracker.DTOs.JoggingRecord;
using Jogging_Tracker.Models;

namespace Jogging_Tracker
{
    public class MapProfiles
    {
        public class ApplicationUserProfile : Profile
        {
            public ApplicationUserProfile()
            {
                CreateMap<ApplicationUser, AccountDto>()
                    .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.Id));
                ;
            }
        }

        public class JoggingRecordProfile : Profile
        {
            public JoggingRecordProfile()
            {
                CreateMap<AddJoggingRecordDto, JoggingRecord>();
                CreateMap<JoggingRecord, JoggingRecordDto>();
            }
        }
    }
}