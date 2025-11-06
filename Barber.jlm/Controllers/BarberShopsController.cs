using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Barber.jlm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BarberShopsController : ControllerBase
    {
        private readonly IBarberShopService _barberShopService;

        public BarberShopsController(IBarberShopService barberShopService)
        {
            _barberShopService = barberShopService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBarberShop([FromBody] BarberShop barberShop)
        {
            try
            {
                var createdBarberShop = await _barberShopService.CreateBarberShop(barberShop);
                return Ok(createdBarberShop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBarberShops()
        {
            try
            {
                var barberShops = await _barberShopService.GetAllBarberShops();
                return Ok(barberShops);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBarberShopById(int id)
        {
            try
            {
                var barberShop = await _barberShopService.GetBarberShopById(id);
                if (barberShop == null)
                {
                    return NotFound();
                }

                return Ok(barberShop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBarberShop(int id, [FromBody] BarberShop barberShop)
        {
            try
            {
                var updatedBarberShop = await _barberShopService.UpdateBarberShop(id, barberShop);
                return Ok(updatedBarberShop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBarberShop(int id)
        {
            try
            {
                var deleted = await _barberShopService.DeleteBarberShop(id);
                if (!deleted)
                {
                    return NotFound();
                }

                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
