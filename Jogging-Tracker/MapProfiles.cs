using AutoMapper;
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
                
                // TODO
                // CreateMap<Models.ActiveProcessesDetails, Dtos.ApdDto>();
                // CreateMap<Models.ActiveProcessesDetails, Dtos.ApdTopUtilizedDto>();
                // CreateMap<Models.ActiveProcessesDetails, Dtos.ApdTopTabsDto>();
                // CreateMap<Models.ActiveProcessesDetails, Dtos.ApdApplicationUsagePercentageDto>();
                // CreateMap<Models.ActiveProcessesDetails, Dtos.ApdTabsUsagePercentageDto>();
                // CreateMap<Models.ActiveProcessesDetails, Dtos.ApdMachineCpuUtilizationDto>()
                //     .ForMember(x => x.UserName, opt => opt.MapFrom(y => y.User.UserName));
                // CreateMap<Dtos.ApdInsertDto, Models.ActiveProcessesDetails>();
            }
        }

        public class JoggingRecordProfile : Profile
        {
            public JoggingRecordProfile()
            {
                CreateMap<AddJoggingRecordDto, JoggingRecord>();
                // TODO
            }
        }
    }
}