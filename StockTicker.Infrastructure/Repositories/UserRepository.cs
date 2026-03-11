using Dapper;
using StockTicker.Application.Abstractions.Authentication;
using StockTicker.Application.Abstractions.Data;
using StockTicker.Application.Repostitories;
using StockTicker.Application.Users.GetLoggedInUser;
using StockTicker.Domain.Users;

namespace StockTicker.Infrastructure.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IUserContext _userContext;

        public UserRepository(
            ISqlConnectionFactory sqlConnectionFactory, 
            IUserContext userContext)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _userContext = userContext;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
            SELECT
                id AS Id,
                first_name AS FirstName,
                last_name AS LastName,
                email AS Email
            FROM users
            WHERE identity_id = @IdentityId
            """;

            var user = await connection.QuerySingleAsync<UserResponse>(
                sql,
                new
                {
                    _userContext.IdentityId
                });

            return user;
        }
    }
}
