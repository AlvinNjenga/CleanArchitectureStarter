using Ardalis.GuardClauses;
using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly ILogger<ArtistController> _logger;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, ILogger<ArtistController> logger, IMapper mapper)
        {
            //guard clauses
            _artistService = Guard.Against.Null(artistService, nameof(artistService));
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
            _logger = Guard.Against.Null(logger, nameof(logger));
        }

        [HttpGet]
        [Route("RetrieveMostActiveArtistsAsync")]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> RetrieveMostActiveArtistsAsync()
        {
            _logger.LogInformation($"RetrieveMostActiveArtistsAsync");

            var results = await _artistService.RetrieveMostActiveArtistAsync();
            return Ok(results);
        }

        [HttpPost]
        [Route("InsertArtistAsync")]
        public async Task<ActionResult<ArtistDTO>> InsertArtistAsync([FromBody] ArtistDTO artist)
        {
            _logger.LogInformation($"InsertArtistAsync - {JsonSerializer.Serialize(artist)}");

            var newArtist = _mapper.Map<Artists>(artist);
            var results = await _artistService.InsertArtistAsync(newArtist);
            return Ok(results);
        }
    }
}
