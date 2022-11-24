using AutoMapper;
using Task6.Application.Common.Mappings;

namespace Task6.Application.CQs.Message.Commands.CreateMessage;

public class ReturnMessageDto : IMapWith<Domain.Message>
{
    public string Sender { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public DateTime DateSend { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Message, ReturnMessageDto>()
            .ForMember(m => m.Body,
                c =>
                    c.MapFrom(m => m.Body))
            .ForMember(m => m.Header,
                c =>
                    c.MapFrom(m => m.Header))
            .ForMember(m => m.DateSend,
                c =>
                    c.MapFrom(m => m.DateSend))
            .ForMember(m => m.Sender,
                c =>
                    c.MapFrom(m => m.Owner.Name));
    }
}