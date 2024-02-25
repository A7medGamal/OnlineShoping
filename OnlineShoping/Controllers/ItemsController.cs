using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoping.Application.DTO;
using OnlineShoping.Application.Service.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineShoping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var againstDto =  itemService.GetAllItem();
                return Ok(againstDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Not Found");
            }
        }

        [HttpGet("GetById/{ItemId:int}")]
        public async Task<IActionResult> GetById(int ItemId)
        {
            try
            {
                if (ItemId != null)
                {
                    var againstDto =  itemService.GetItemById(ItemId);
                    return Ok(againstDto);
                }
                else
                {
                 throw new Exception("Not Found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Not Found");

            }
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem([FromBody] ItemDto AddItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     itemService.CreateItem(AddItem);
                    return Ok();
                }
                else
                {
                    throw new Exception("Not Valid Data");
                }

            }
            catch (Exception ex)
            {
                    throw new Exception("Not Valid Data");

            }
        }

        [HttpPut("EditItem")]
        public async Task<IActionResult> EditItem([FromBody] ItemDto EditItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     itemService.UpdateItem(EditItem,EditItem.Id);
                    return Ok();
                }
                else
                {
                    throw new ("Not Valid Data");
                }
            }

            catch (Exception ex)
            {
                throw new Exception("in Logic Error");
            }
        }
        [HttpDelete("DeleteItem/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                return Ok( itemService.DeleteItem(id));
            }
            catch (Exception ex)
            {
                throw new ("Not Valid Data");
            }
        }
    }
}
