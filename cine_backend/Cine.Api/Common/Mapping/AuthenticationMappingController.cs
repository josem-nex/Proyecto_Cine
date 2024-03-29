namespace Cine.Api.Common.Mapping;

using Cine.Api.Controllers;
using Cine.Application.Authentication.Commands.Register;
using Cine.Application.Authentication.Commands.Update;
using Cine.Application.Authentication.Common;
using Cine.Application.Authentication.Queries.GetAll;
using Cine.Application.Authentication.Querys.Login;
using Cine.Application.Models.Admins.Commands;
using Cine.Application.Models.Admins.Queries.Get;
using Cine.Application.Models.Admins.Queries.GetAll;
using Cine.Application.Models.Admins.Queries.Login;
using Cine.Application.Models.Countries.Commands.Add;
using Cine.Application.Models.Countries.Queries.GetAll;
using Cine.Application.Models.Countries.Queries.GetOne;
using Cine.Application.Models.Halls.Commands;
using Cine.Application.Models.Halls.Queries;
using Cine.Application.Models.Movies.Commands.AddMovie;
using Cine.Application.Models.Movies.Commands.UpdateMovie;
using Cine.Application.Models.Movies.Queries.GetAll;
using Cine.Application.Models.Movies.Queries.GetOne;
using Cine.Application.Models.Schedules.Commands;
using Cine.Application.Models.Schedules.Queries.Get;
using Cine.Application.Models.Schedules.Queries.GetAll;
using Cine.Application.Models.ShowTimes;
using Cine.Contracts.Authentication;
using Mapster;

/* 

    public record DeleteShowTimeCommand(int Id) : IRequest<ErrorOr<Unit>>;
    public record DeleteShowTimeRequest(int Id);
    public class DeleteShowTimeCommandHandler : IRequestHandler<DeleteShowTimeCommand, ErrorOr<Unit>>
    {
        private readonly IShowTimeRepository _ShowTimeRepository;
        public DeleteShowTimeCommandHandler(IShowTimeRepository ShowTimeRepository)
        {
            _ShowTimeRepository = ShowTimeRepository;
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteShowTimeCommand request, CancellationToken cancellationToken)
        {
            ShowTime? ShowTime = await _ShowTimeRepository.GetShowTimeById(request.Id);
            if (ShowTime is null)
            {
                return Errors.ShowTime.ShowTimeNotFound;
            }
            await _ShowTimeRepository.Delete(ShowTime);
            return Unit.Value;
        }
    }

    public record GetShowTimeRequest(int Id);
    public record GetShowTimeResponse(int Id, int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId);
    public record GetShowTimeResult(ShowTime ShowTime);
    public record GetShowTimeQuery(int Id) : IRequest<ErrorOr<GetShowTimeResult>>;
    public class GetShowTimeQueryHandler : IRequestHandler<GetShowTimeQuery, ErrorOr<GetShowTimeResult>>
    {
        private readonly IShowTimeRepository _ShowTimeRepository;
        public GetShowTimeQueryHandler(IShowTimeRepository ShowTimeRepository)
        {
            _ShowTimeRepository = ShowTimeRepository;
        }
        public async Task<ErrorOr<GetShowTimeResult>> Handle(GetShowTimeQuery request, CancellationToken cancellationToken)
        {
            ShowTime? ShowTime = await _ShowTimeRepository.GetShowTimeById(request.Id);
            if (ShowTime is null)
            {
                return Errors.ShowTime.ShowTimeNotFound;
            }
            return new GetShowTimeResult(ShowTime);
        }
    }

    public record AddShowTimeCommand(int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId) : IRequest<ErrorOr<GetShowTimeResult>>;
    public record AddShowTimeRequest(int HallsId, int SchedulesId, int Cost, int CostPoints, int MovieId);
    public class AddShowTimeCommandHandler : IRequestHandler<AddShowTimeCommand, ErrorOr<GetShowTimeResult>>
    {
        private readonly IShowTimeRepository _ShowTimeRepository;
        private readonly IHallRepository _HallRepository;
        private readonly IScheduleRepository _ScheduleRepository;
        private readonly IMovieRepository _MovieRepository;
        public AddShowTimeCommandHandler(IShowTimeRepository ShowTimeRepository, IHallRepository HallRepository, IScheduleRepository ScheduleRepository, IMovieRepository MovieRepository)
        {
            _ShowTimeRepository = ShowTimeRepository;
            _HallRepository = HallRepository;
            _ScheduleRepository = ScheduleRepository;
            _MovieRepository = MovieRepository;
        }
        public async Task<ErrorOr<GetShowTimeResult>> Handle(AddShowTimeCommand request, CancellationToken cancellationToken)
        {
            Hall? Halls = await _HallRepository.GetHallById(request.HallsId);
            if (Halls is null)
            {
                return Errors.Hall.HallNotFound;
            }
            Schedule? Schedules = await _ScheduleRepository.GetScheduleById(request.SchedulesId);
            if (Schedules is null)
            {
                return Errors.Schedule.ScheduleNotFound;
            }
            Movie? Movie = await _MovieRepository.GetMovieById(request.MovieId);
            if (Movie is null)
            {
                return Errors.Movie.MovieNotFound;
            }
            ShowTime ShowTime = new ShowTime(request.HallsId, request.SchedulesId, request.Cost, request.CostPoints, request.MovieId);
            await _ShowTimeRepository.Add(ShowTime);
            return new GetShowTimeResult(ShowTime);
        }
    }
    public record GetAllShowTimesResult(List<ShowTime> ShowTimes);
    public record GetAllShowTimesQuery() : IRequest<ErrorOr<GetAllShowTimesResult>>;
    public class GetAllShowTimesQueryHandler : IRequestHandler<GetAllShowTimesQuery, ErrorOr<GetAllShowTimesResult>>
    {
        private readonly IShowTimeRepository _ShowTimeRepository;
        public GetAllShowTimesQueryHandler(IShowTimeRepository ShowTimeRepository)
        {
            _ShowTimeRepository = ShowTimeRepository;
        }
        public async Task<ErrorOr<GetAllShowTimesResult>> Handle(GetAllShowTimesQuery request, CancellationToken cancellationToken)
        {
            List<ShowTime> ShowTimes = await _ShowTimeRepository.GetShowTimeList();
            return new GetAllShowTimesResult(ShowTimes);
        }
    }
 */


public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterPartnerCommand>();
        config.NewConfig<UpdatePartnerRequest, UpdatePartnerCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.Partner);

        config.NewConfig<GetPartnerListResult, GetPartnerListResult>()
            .ConstructUsing(src => new GetPartnerListResult(src.Partners));

        config.NewConfig<AddAdminRequest, AddAdminCommand>();
        config.NewConfig<GetAdminResult, GetAdminResponse>()
            .Map(dest => dest, src => src.Admin);
        config.NewConfig<AddAdminResult, GetAdminResponse>()
            .Map(dest => dest, src => src.Admin);
        config.NewConfig<GetAdminRequest, GetAdminQuery>();
        config.NewConfig<GetAllAdminResult, GetAllAdminResult>()
            .ConstructUsing(src => new GetAllAdminResult(src.Admins));
        config.NewConfig<LoginAdminRequest, LoginAdminQuery>();




        config.NewConfig<GetAllMoviesResult, GetAllMoviesResult>()
            .ConstructUsing(src => new GetAllMoviesResult(src.Movies));
        config.NewConfig<AddMovieResult, AddMovieResponse>()
            .Map(dest => dest, src => src.Movie);
        config.NewConfig<GetMovieResult, GetMovieResponse>()
            .Map(dest => dest.Id, src => src.Movie.Id)
            .Map(dest => dest.Title, src => src.Movie.Title)
            .Map(dest => dest.Description, src => src.Movie.Description)
            .Map(dest => dest.Director, src => src.Movie.Director)
            .Map(dest => dest.ImageUrl, src => src.Movie.ImageUrl)
            .Map(dest => dest.DurationMinutes, src => src.Movie.DurationMinutes)
            .Map(dest => dest.ReleaseDate, src => src.Movie.ReleaseDate)
            .Map(dest => dest.Language, src => src.Movie.Language)
            .Map(dest => dest.Rating, src => src.Movie.Rating)
            // .Map(dest => dest.Country, src => src.Movie.Country)
            .Map(dest => dest.CountryId, src => src.Movie.CountryId);
        config.NewConfig<GetMovieRequest, GetMovieQuery>();
        config.NewConfig<UpdateMovieRequest, UpdateMovieCommand>();

        config.NewConfig<GetAllCountriesQuery, GetAllCountriesQuery>();
        config.NewConfig<GetAllCountriesResult, GetAllCountriesResult>()
            .ConstructUsing(src => new GetAllCountriesResult(src.Countries));

        config.NewConfig<AddCountryRequest, AddCountryCommand>();
        config.NewConfig<AddCountryResult, AddCountryResponse>()
            .Map(dest => dest, src => src.Country);
        config.NewConfig<GetCountryRequest, GetCountryQuery>();
        config.NewConfig<GetCountryResult, GetCountryResponse>()
            .Map(dest => dest, src => src.Country);

        config.NewConfig<AddHallRequest, AddHallCommand>();
        config.NewConfig<AddHallResult, AddHallResponse>()
            .Map(dest => dest, src => src.Hall);
        config.NewConfig<UpdateHallRequest, UpdateHallCommand>();
        config.NewConfig<GetHallRequest, GetHallQuery>();
        config.NewConfig<GetHallResult, GetHallResponse>()
            .Map(dest => dest, src => src.Hall);
        config.NewConfig<GetAllHallsResult, GetAllHallsResult>()
            .ConstructUsing(src => new GetAllHallsResult(src.Halls));


        config.NewConfig<GetAllSchedulesResult, GetAllSchedulesResult>()
            .ConstructUsing(src => new GetAllSchedulesResult(src.Schedules));
        config.NewConfig<AddScheduleRequest, AddScheduleCommand>();
        config.NewConfig<GetScheduleResult, GetScheduleResponse>()
            .Map(dest => dest, src => src.Schedule);
        config.NewConfig<GetScheduleRequest, GetScheduleQuery>();
        config.NewConfig<UpdateScheduleRequest, UpdateScheduleCommand>();
        config.NewConfig<DeleteScheduleRequest, DeleteScheduleCommand>();


        config.NewConfig<AddShowTimeRequest, AddShowTimeCommand>();
        config.NewConfig<GetShowTimeResult, GetShowTimeResponse>()
            .Map(dest => dest.Id, src => src.ShowTime.Id)
            .Map(dest => dest.HallsId, src => src.ShowTime.HallsId)
            .Map(dest => dest.SchedulesId, src => src.ShowTime.SchedulesId)
            .Map(dest => dest.Cost, src => src.ShowTime.Cost)
            .Map(dest => dest.CostPoints, src => src.ShowTime.CostPoints)
            .Map(dest => dest.MovieId, src => src.ShowTime.MovieId);
        config.NewConfig<GetShowTimeRequest, GetShowTimeQuery>();
        config.NewConfig<DeleteShowTimeRequest, DeleteShowTimeCommand>();
        config.NewConfig<GetAllShowTimesResult, GetAllShowTimesResult>()
            .ConstructUsing(src => new GetAllShowTimesResult(src.ShowTimes));
    }
}