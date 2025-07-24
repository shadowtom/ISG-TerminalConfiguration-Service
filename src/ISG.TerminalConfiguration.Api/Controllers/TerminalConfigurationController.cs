using ISG.TerminalConfiguration.Api.DTO.Responses;
using ISG.TerminalConfiguration.Domain.Entities.Terminals;
using ISG.TerminalConfiguration.Domain.Interfaces.Services;
using ISG.TerminalConfiguration.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ISG.TerminalConfiguration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TerminalConfigurationController : Controller
    {
        private readonly ITerminalConfigurationService _terminalConfigurationService;
        public TerminalConfigurationController(IServiceProvider serviceProvider)
        {
            _terminalConfigurationService = serviceProvider.GetRequiredService<ITerminalConfigurationService>();
        }

        [HttpGet("GetTerminalInformation/{KioskID}")]
        public async Task<IActionResult> GetTerminalInformation(Guid KioskID)
        {
            try
            {
                var response = await _terminalConfigurationService.GetTerminalInformationAsync(KioskID);
                TerminalDTO terminalInfo = Mappers.TerminalMapper.mapToTerminalDTO(
                    response.Configuration,
                    response.Security);
                return Ok(terminalInfo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving terminal information: {ex.Message}");
            }
        }
        [HttpGet("GetTerminalsInfoByClientID/{clientID}")]
        public async Task<IActionResult> GetTerminalsInfoByClientID(Guid clientID)
        {
            try
            {
                var response = await _terminalConfigurationService.GetTerminalsInfoByClientIDAsync(clientID);
                List<TerminalDTO> terminalsInfo = response.Select(t => Mappers.TerminalMapper.mapToTerminalDTO(
                    t.Configuration,
                    t.Security)).ToList();
                return Ok(terminalsInfo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving terminals information: {ex.Message}");
            }
        }
        [HttpPost("AddTerminalConfiguration")]
        public async Task<IActionResult> AddTerminalConfiguration([FromBody] RequestTerminalConfigurationDTO terminalConfiguration)
        {
            try
            {
                TerminalConfig mappedResponse = Mappers.TerminalMapper.mapToTerminalConfiguration(terminalConfiguration);
                await _terminalConfigurationService.AddTerminalConfigurationAsync(mappedResponse);
                return Ok("Terminal configuration added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding terminal configuration: {ex.Message}");
            }
        }
        [HttpDelete("DeleteTerminalWithKioskID/{KioskID}")]
        public async Task<IActionResult> DeleteTerminalWithKioskID(Guid KioskID)
        {
            try
            {
                await _terminalConfigurationService.deleteTerminalConfigurationWithKioskID(KioskID);
                return Ok("Terminal configuration deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting terminal configuration: {ex.Message}");
            }
        }

        [HttpDelete("DeleteTerminalWithTerminalID/{TerminalID}")]
        public async Task<IActionResult> DeleteTerminalWithTerminalID(Guid TerminalID)
        {
            try
            {
                await _terminalConfigurationService.deleteTerminalConfigurationWithTerminalID(TerminalID);
                return Ok("Terminal configuration deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting terminal configuration: {ex.Message}");
            }
        }
        [HttpPut("UpdateTerminalConfiguration")]
        public async Task<IActionResult> UpdateTerminalConfiguration([FromBody] RequestTerminalConfigurationDTO terminalConfiguration)
        {
            try
            {
                TerminalConfig mappedResponse = Mappers.TerminalMapper.mapToTerminalConfiguration(terminalConfiguration);
                await _terminalConfigurationService.UpdateTerminalConfigurationAsync(mappedResponse);
                return Ok("Terminal configuration updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating terminal configuration: {ex.Message}");
            }
        }
    }
}
