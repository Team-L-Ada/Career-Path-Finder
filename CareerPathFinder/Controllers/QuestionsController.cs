namespace CareerPathFinder.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using CareerPathFinder.Models.Database;
    using CareerPathFinder.Models;

    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public QuestionsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("all")]
        public IEnumerable<string> GetQuestions()
        {
            return _appDbContext.Questions.Select(question => question.Content);
        }

        public class CareerMatch
        {
            public string Name { get; set; }

            public float Percentage { get; set; }
        }

        public class AnswerResponse
        {
            public CareerMatch[] CareerMatches { get; set; }
        }

        [HttpPost("answer")]
        public IActionResult Answer([FromBody] Dictionary<string, string> answers)
        {
            Category[] categories = _appDbContext.Categories
                                                 .OrderBy(cat => cat.Order)
                                                 .ToArray();

            Career[] careers = _appDbContext.Careers.ToArray();

            List<Career> matchingCareers = new List<Career>();

            for (int category = 1; category <= categories.Length; ++category)
            {
                if (bool.Parse(answers[category.ToString()]))
                {
                    matchingCareers.Add(categories[category - 1].Career);
                }
            }

            int[] careerFrequencies = new int[careers.Length];

            for (int index = 0; index < careers.Length; ++index)
            {
                careerFrequencies[index] = matchingCareers.Count(career => career.Id == careers[index].Id);
            }

            int sum = careerFrequencies.Sum();

            CareerMatch[] careerMatches = new CareerMatch[careers.Length];

            for (int index = 0; index < careers.Length; ++index)
            {
                float percentage;

                if (sum > 0)
                {
                    percentage = (float)careerFrequencies[index] / (float)sum;
                }
                else
                {
                    percentage = 1.0f / careers.Length;
                }

                careerMatches[index] = new CareerMatch
                {
                    Name = careers[index].Name,
                    Percentage = percentage
                };
            }

            return Ok(new AnswerResponse
            {
                CareerMatches = careerMatches
            });
        }
    }
}