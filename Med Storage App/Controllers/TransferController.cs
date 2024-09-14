using System.Security.Cryptography.Xml;
using Med_Storage_App.Data;
using Med_Storage_App.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            var transfers = await _db.Transfers.Include(p => p.Products).ToListAsync();
            if (transfers == null) return NotFound("Transfer Not Found");
            return Ok(transfers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transfer>> FindTransfer(int id)
        {
            var transfer = await _db.Transfers.Include(p => p.Products).FirstOrDefaultAsync(t => t.TransferId == id);
            if (transfer == null) return NotFound("Transfer Not Found");
            return Ok(transfer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransfer([FromBody]Transfer newTransfer)
        {
            _db.Transfers.Add(newTransfer);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(FindTransfer), new { id = newTransfer.TransferId }, newTransfer);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransfer(Transfer newTransfer, int id)
        {
            if (id != newTransfer.TransferId) return BadRequest("Transfer ID mismatch");
            if(newTransfer == null) return BadRequest("Transfer cannot be null");
            var oldTransfer = await _db.Transfers.FindAsync(newTransfer.TransferId);
            if (oldTransfer == null) return BadRequest("Transfer not Found");
            oldTransfer.TransferId = newTransfer.TransferId;
            oldTransfer.TransferCreator = newTransfer.TransferCreator;
            oldTransfer.TransferDestination = newTransfer.TransferDestination;
            oldTransfer.TransferStatus = newTransfer.TransferStatus;
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleleTransfer(int id)
        {
            var transfer = await _db.Transfers.FindAsync(id);
            if (transfer == null) return NotFound("Transfer Not Found");
            _db.Transfers.Remove(transfer);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
