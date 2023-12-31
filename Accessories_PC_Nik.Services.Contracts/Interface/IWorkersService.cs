﻿using Accessories_PC_Nik.Services.Contracts.ModelRequest;
using Accessories_PC_Nik.Services.Contracts.Models;

namespace Accessories_PC_Nik.Services.Contracts.Interface
{
    public interface IWorkersService
    {
        /// <summary>
        /// Получить список всех <see cref="WorkerModel"/>
        /// </summary>
        Task<IEnumerable<WorkerModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="WorkerModel"/> по идентификатору
        /// </summary>
        Task<WorkerModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового работника
        /// </summary>
        Task<WorkerModel> AddAsync(WorkerRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего работника
        /// </summary>
        Task<WorkerModel> EditAsync(WorkerRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего работника по ключу доступа
        /// </summary>
        Task<WorkerModel> EditWithAccessKeyAsync(Guid id, Guid key, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего работника
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
