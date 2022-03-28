using Application.Dto;
using Application.Models;
using Application.Respository;
using Application.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        protected IOnboarding _onboarding;

        public OnboardingController(IOnboarding onboarding)
        {
            _onboarding = onboarding;
        }

        [HttpGet("VerifyEmail/{Email}")]
        public async Task<ActionResult> VerifyEmail(string Email)
        {
            return Ok(await _onboarding.VerifyEmail(Email));
        }

        [HttpGet("VerifyPhone/{Phone}")]
        public async Task<ActionResult> VerifyPhone(string Phone)
        {
            return Ok(await _onboarding.VerifyPhone(Phone));
        }

        [HttpPost("Onboarding")]
        public async Task<ActionResult<OnboardingDto>> AddOnboarding(OnbardingRequest request)
        {
            OnbardingRequestValidator validator = new OnbardingRequestValidator();
            ValidationResult results = validator.Validate(request);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return BadRequest(failure.ErrorMessage);
                }
            }
            return Ok(await _onboarding.AddOnboarding(request));
        }

        [HttpGet("GetAllOnboarding")]
        public async Task<ActionResult<List<OnboardingResponse>>> GetAllOnboarding()
        {
            return Ok(await _onboarding.GetAllOnboarding());
        }

        [HttpGet("GetOnboardingByEmail/{Email}")]
        public async Task<ActionResult<OnboardingResponse>> GetOnboardingByEmail(string Email)
        {
            return Ok(await _onboarding.GetOnboardingByEmail(Email));
        }

        [HttpGet("GetOnboardingByPhone/{Phone}")]
        public async Task<ActionResult<OnboardingResponse>> GetOnboardingByPhone(string Phone)
        {
            return Ok(await _onboarding.GetOnboardingByPhone(Phone));
        }

    }
}
