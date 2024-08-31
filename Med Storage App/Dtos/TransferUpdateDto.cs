﻿using Med_Storage_App.Entities;

namespace Med_Storage_App.Dtos
{
    public class TransferUpdateDto
    {
        public int Id { get; set; }
        public string DestinationName { get; set; }
        public TransferStatus TransferStatus { get; set; }
        public List<TransferItemDto> TransferItems { get; set; }
    }
}
