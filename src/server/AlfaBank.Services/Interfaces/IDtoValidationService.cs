using System.Collections.Generic;
using AlfaBank.Core.Exceptions;
using AlfaBank.Core.Models.Dto;

namespace AlfaBank.Services.Interfaces
{
    /// <summary>
    /// Service for validation DTO
    /// </summary>
    public interface IDtoValidationService
    {
        /// <summary>
        /// Method to validate transfer
        /// </summary>
        /// <param name="transaction">transaction DTO</param>
        IEnumerable<CustomModelError> ValidateTransferDto(TransactionPostDto transaction);

        /// <summary>
        /// Method to validate card dto
        /// </summary>
        /// <param name="card">card DTO</param>
        IEnumerable<CustomModelError> ValidateOpenCardDto(CardPostDto card);
    }
}