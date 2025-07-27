using Microsoft.AspNetCore.Mvc;
using SentimentMiddleTier.Models;
using SentimentMiddleTier.Services;

namespace SentimentMiddleTier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentController(SentimentService service) : ControllerBase
    {
        private readonly SentimentService _service = service;

        [HttpPost("PredictSentiment")]
        public async Task<ActionResult<SentimentResponse>> PredictSentiment([FromBody] SentimentRequest input)
        {
            var result = await _service.PredictAsync(input);
            return Ok(result);
        }
    }
}

