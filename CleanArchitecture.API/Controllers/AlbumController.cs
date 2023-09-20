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
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly ILogger<AlbumController> _logger;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService, ILogger<AlbumController> logger, IMapper mapper)
        {
            //guard clauses
            _albumService = Guard.Against.Null(albumService, nameof(albumService));
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
            _logger = Guard.Against.Null(logger, nameof(logger));
        }

        [HttpGet]
        [Route("RetrieveLatestAlbumsAsync")]
        public async Task<ActionResult<IEnumerable<AlbumDTO>>> RetrieveLatestAlbumsAsync()
        {
            _logger.LogInformation($"RetrieveLatestAlbumsAsync");

            var results = await _albumService.RetrieveCommonAlbumsAsync();
            var AlbumDto = _mapper.Map<IEnumerable<AlbumDTO>>(results);
            return Ok(AlbumDto);
        }

        [HttpPost]
        [Route("InsertAlbumAsync")]
        public async Task<ActionResult<AlbumDTO>> InsertAlbumAsync([FromBody] AlbumDTO album)
        {
            _logger.LogInformation($"InsertAlbumAsync - {JsonSerializer.Serialize(album)}");

            var newAlbum = _mapper.Map<Albums>(album);
            var results = await _albumService.InsertNewAlbumAsync(newAlbum);
            return Ok(results);
        }

        [HttpPut]
        [Route("UpdateAlbumAsync")]
        public async Task<ActionResult<AlbumDTO>> UpdateAlbumAsync([FromBody] AlbumDTO album)
        {
            _logger.LogInformation($"UpdateAlbumAsync - {JsonSerializer.Serialize(album)}");

            var newAlbum = _mapper.Map<Albums>(album);
            var results = await _albumService.UpdateAlbumAsync(newAlbum);
            return Ok(results);
        }
    }
}
