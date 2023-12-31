﻿using Accessories_PC_Nik.Services.Contracts.ModelRequest;
using Accessories_PC_Nik.Services.Contracts.Models;

namespace Accessories_PC_Nik.Services.Contracts.Interface
{
    public interface IComponentsService
    {
        /// <summary>
        /// Получить список всех <see cref="ComponentModel"/>
        /// </summary>
        Task<IEnumerable<ComponentModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="ComponentModel"/> по идентификатору
        /// </summary>
        Task<ComponentModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);


        /// <summary>
        /// Добавляет новый компонент
        /// </summary>
        Task<ComponentModel> AddAsync(ComponentRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий компонент
        /// </summary>
        Task<ComponentModel> EditAsync(ComponentRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий компонент
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
