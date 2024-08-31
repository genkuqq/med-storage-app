using Med_Storage_App.Data;
using Med_Storage_App.Dtos;
using Med_Storage_App.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Med_Storage_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly Database _db;
        public TransferController(Database db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Transfer>>> GetAllTransfers()
        {
            var transfers = await _db.Transfers
                .Include(t => t.TransferItems)
                .ThenInclude(ti => ti.Product)
                .Select(t => new Transfer
                {
                    Id = t.Id,
                    CreatorName = t.CreatorName,
                    DestinationName = t.DestinationName,
                    TransferStatus = t.TransferStatus,
                    TransferDate = t.TransferDate,
                    TransferItems = t.TransferItems.Select(ti => new TransferItem
                    {
                        ProductId = ti.ProductId,
                        Quantity = ti.Quantity
                    }).ToList()
                })
                .ToListAsync();

            if (transfers == null || transfers.Count == 0) return NotFound("Transfers Not Found");
            return Ok(transfers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transfer>> FindTransfer(int id)
        {
            var transfer = await _db.Transfers
                .Include(t => t.TransferItems)
                .ThenInclude(ti => ti.Product)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transfer == null)
            {
                return NotFound("Transfer Not Found");
            }
            return Ok(transfer);
        }

        [HttpPost]
        public async Task<ActionResult<TransferCreateDto>> CreateTransfer(TransferCreateDto newtransfer)
        {
            var transfer = new Transfer
            {
                CreatorName = newtransfer.CreatorName,
                DestinationName = newtransfer.DestinationName,
                TransferStatus = TransferStatus.Ongoing,
                TransferDate = DateTime.Now,
                TransferItems = newtransfer.TransferItems.Select(ti => new TransferItem
                {
                    ProductId = ti.ProductId,
                    Quantity = ti.Quantity
                }).ToList()
            };

            _db.Transfers.Add(transfer);
            await _db.SaveChangesAsync();
            return Ok(transfer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransfer(TransferUpdateDto transferDto, int id)
        {
            if (id != transferDto.Id) return BadRequest("Transfer ID mismatch");

            var transfer = await _db.Transfers.FindAsync(id);

            if (transfer == null) return NotFound("Transfer Not Found");

            transfer.DestinationName = transferDto.DestinationName;
            transfer.TransferStatus = transferDto.TransferStatus;
            transfer.TransferItems = transferDto.TransferItems.Select(ti => new TransferItem
            {
                ProductId = ti.ProductId,
                Quantity = ti.Quantity
            }).ToList();

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransfer(int id)
        {
            var transfer = await _db.Transfers.FindAsync(id);

            if (transfer == null) return NotFound("Transfer Not Found");

            _db.Transfers.Remove(transfer);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
