using ISG.TerminalConfiguration.Api.DTO.Requests;
using ISG.TerminalConfiguration.Api.Mappers;
using ISG.TerminalConfiguration.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISG.TerminalConfiguration.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KioskController : Controller
    {
        private readonly IKioskService _kioskService;
        public KioskController(IServiceProvider serviceProvider)
        {
            _kioskService = serviceProvider.GetRequiredService<IKioskService>();
        }

        [HttpGet("GetKioskInformation/{KioskID}")]
        public async Task<IActionResult> GetKioskInformation(Guid KioskID)
        {
            try
            {
                var response = await _kioskService.GetKioskByIdAsync(KioskID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving kiosk information: {ex.Message}");
            }
        }
        [HttpGet("GetKiosksByClientID/{clientID}")]
        public async Task<IActionResult> GetKiosksByClientID(Guid clientID)
        {
            try
            {
                var response = await _kioskService.GetKioskIdsByClientIdAsync(clientID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving kiosks information: {ex.Message}");
            }
        }
        [HttpPost("AddKiosk")]
        public async Task<IActionResult> AddKiosk([FromBody] KioskRequestDTO kiosk)
        {
            try
            {
                await _kioskService.AddKioskAsync(KioskMapper.mapToKiosk(kiosk));
                return Ok("Kiosk added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding kiosk: {ex.Message}");
            }
        }
        [HttpPut("UpdateKiosk")]
        public async Task<IActionResult> UpdateKiosk([FromBody] KioskRequestDTO kiosk)
        {
            try
            {
                await _kioskService.UpdateKioskAsync(KioskMapper.mapToKiosk(kiosk));
                return Ok("Kiosk updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating kiosk: {ex.Message}");
            }
        }
        [HttpDelete("DeleteKiosk/{KioskID}")]
        public async Task<IActionResult> DeleteKiosk(Guid KioskID)
        {
            try
            {
                if(await _kioskService.DeleteKioskAsync(KioskID))
                {
                    return Ok("Kiosk deleted successfully.");
                }
                return NotFound($"Kiosk with ID {KioskID} not found.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting kiosk: {ex.Message}");
            }
        }
    }
}
