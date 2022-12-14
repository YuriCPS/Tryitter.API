using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.API.Contracts;
using Tryitter.API.Data;
using Tryitter.API.Models.Tweet;

namespace Tryitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IMapper _mapper;

        public TweetsController(ITweetRepository tweetRepository, IMapper mapper)
        {
            _tweetRepository = tweetRepository;
            _mapper = mapper;
        }

        // GET: api/Tweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTweetDto>>> GetTweets()
        {
            var tweets = await _tweetRepository.GetAllAsync();
            var tweetsList = _mapper.Map<List<GetTweetDto>>(tweets);

            return Ok(tweetsList);
        }

        // GET: api/Tweets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetTweetDetailsDto>> GetTweet(int id)
        {
            var tweet = await _tweetRepository.GetById(id);
            if (tweet == null)
            {
                return NotFound("Tweet not found");
            }
            var tweetDto = _mapper.Map<GetTweetDetailsDto>(tweet);

            return Ok(tweetDto);
        }

        // GET: api/Tweets/Last
        [HttpGet("Last")]
        public async Task<ActionResult<GetTweetDetailsDto>> GetLastTweet()
        {
            var tweets = await _tweetRepository.GetAllAsync();
            if (tweets == null || tweets.Count == 0)
            {
                return NotFound("No tweets found");
            }
            var tweetsList = _mapper.Map<List<GetTweetDetailsDto>>(tweets);
            tweetsList = tweetsList.OrderByDescending(t => t.CreatedAt).ToList();

            return Ok(tweetsList[0]);
        }

        // GET: api/Tweets/UserId/2
        [HttpGet("UserId/{id}")]
        public async Task<ActionResult<IEnumerable<GetTweetDto>>> GetTweetsByUserId(int id)
        {
            var tweets = await _tweetRepository.GetByUser(id);
            if (tweets == null || tweets.Count == 0)
            {
                return NotFound("No tweets found");
            }

            var tweetsList = _mapper.Map<List<GetTweetDto>>(tweets);

            return Ok(tweetsList);
        }

        // GET: api/Tweets/UserId/Last/2
        [HttpGet("UserId/Last/{id}")]
        public async Task<ActionResult<IEnumerable<GetTweetDetailsDto>>> GetLastTweetByUserId(int id)
        {
            var tweets = await _tweetRepository.GetByUser(id);
            if (tweets == null || tweets.Count == 0)
            {
                return NotFound("No tweets found");
            }

            var tweetsList = _mapper.Map<List<GetTweetDetailsDto>>(tweets);
            tweetsList = tweetsList.OrderByDescending(t => t.CreatedAt).ToList();

            return Ok(tweetsList[0]);
        }

        // PUT: api/Tweets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweet(int id, UpdateTweetDto updateTweetDto)
        {
            if (id != updateTweetDto.Id)
            {
                return BadRequest("Invalid tweet id");
            }

            var tweet = await _tweetRepository.GetAsync(id);
            if (tweet == null)
            {
                return NotFound("Tweet not found");
            }

            if (updateTweetDto.UserId != tweet.UserId)
            {
                return BadRequest("Invalid user id, must be the same as the tweet's user id");
            }

            _mapper.Map(updateTweetDto, tweet);
            tweet.UpdatedAt = DateTime.Now;
            
            try
            {
                await _tweetRepository.UpdateAsync(tweet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TweetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tweets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetTweetDetailsDto>> PostTweet(CreateTweetDto createTweetDto)
        {
            if(createTweetDto.UserId == 0)
            {
                return BadRequest("Invalid user id");
            }
            var tweet = _mapper.Map<Tweet>(createTweetDto);
            tweet.CreatedAt = DateTime.Now;
            tweet.UpdatedAt = DateTime.Now;
            
            await _tweetRepository.AddAsync(tweet);

            return CreatedAtAction("GetTweet", new { id = tweet.Id }, tweet);
        }
        
        // DELETE: api/Tweets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTweet(int id)
        {
            var tweet = await _tweetRepository.GetAsync(id);
            if (tweet == null)
            {
                return NotFound("Tweet not found");
            }
            await _tweetRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> TweetExists(int id)
        {
            return await _tweetRepository.Exists(id);
        }
    }
}
