﻿using Accessories_PC_Nik.Common;
using Accessories_PC_Nik.Common.Entity.InterfaceDB;

namespace Accessories_PC_Nik.Api.Infrastructures
{
    /// <inheritdoc cref="IDbWriterContext"/>
    public class DbWriterContext : IDbWriterContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DbWriterContext"/>
        /// </summary>
        /// <remarks>
        /// В реальном проекте надо добавлять IIdentity для доступа
        /// к информации об авторизации
        /// </remarks>
        public DbWriterContext(
            IDbWriter writer,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            Writer = writer;
            UnitOfWork = unitOfWork;
            DateTimeProvider = dateTimeProvider;
        }

        /// <inheritdoc/>
        public IDbWriter Writer { get; }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork { get; }

        /// <inheritdoc/>
        public IDateTimeProvider DateTimeProvider { get; }

        /// <inheritdoc/>
        public string UserName { get; } = "Accessories_PC_Nik.Api";
    }
}
