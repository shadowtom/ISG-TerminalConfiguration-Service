using ISG.TerminalConfiguration.Api.DTO.Requests;
using ISG.TerminalConfiguration.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISG.TerminalConfiguration.Api.Controllers
{
    public class TerminalSecurityController : Controller
    {
        private readonly ITerminalSecurityService _terminalSecurityService;

        public TerminalSecurityController(IServiceProvider serviceProvider)
        {
            _terminalSecurityService = serviceProvider.GetRequiredService<ITerminalSecurityService>();
        }

        [HttpPost("updateSecurity")]
        public async Task<IActionResult> UpdateSecurity(string terminalId, string token, DateTime expirationDate)
        {
            try
            {
                await _terminalSecurityService.AddOrUpdateTerminalSecurityAsync(terminalId, token, expirationDate);
                return Ok("Terminal security updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating terminal security: {ex.Message}");
            }
        }


        [HttpGet("validateSecurity")]
        public async Task<IActionResult> ValidateSecurity(string terminalId, string token)
        {
            try
            {
                var isValid = await _terminalSecurityService.ValidateTerminalSecurityAsync(terminalId, token);
                if (isValid)
                {
                    return Ok("Terminal security is valid.");
                }
                else
                {
                    return Unauthorized("Invalid terminal security.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error validating terminal security: {ex.Message}");
            }

        }
        [HttpPost("AddNewTerminalToken")]
        public async Task<IActionResult> AddNewTerminalToken([FromBody] TerminalSecurityRequestDTO securityRequestDTO)
        {
            try
            {

                await _terminalSecurityService.AddNewTerminalTokenAsync(Mappers.TerminalSecurityMapper.mapToTerminalSecurity(securityRequestDTO));
                return Ok("New terminal token added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding new terminal token: {ex.Message}");
            }
        }
    }
}
