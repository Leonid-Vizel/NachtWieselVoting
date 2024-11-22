using Microsoft.EntityFrameworkCore;
using NachtWieselVoting.BusinessLogic.Dto.Users;
using NachtWieselVoting.Data.Contexts;
using NachtWieselVoting.Data.Entities;

namespace NachtWieselVoting.BusinessLogic.DataServices;

public interface IUserService
{
    Task LoginExistsAsync(string login);
    Task<UserEntity?> FindAsync(int id);
    Task<UserProfileData?> FindProfileAsync(int id);
    Task RegitserAsync(string login, string password);
    Task<UserEntity?> FindByLoginAndPassword(string login, string password);
    Task UpdateAsync(UserEntity entity);
}

public sealed class UserService(NachtWieselVotingDbContext context) : IUserService
{
    public Task LoginExistsAsync(string login)
        => context.Users.AnyAsync(x=>x.Login.ToLower() == login.ToLower());

    public async Task<UserEntity?> FindByLoginAndPassword(string login, string password)
    {
        var found = await context.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Login.ToLower() == login.ToLower());
        if (found == null)
        {
            return null;
        }
        if (!BCrypt.Net.BCrypt.Verify(password, found.Password))
        {
            return null;
        }
        return found;
    }

    public async Task<UserProfileData?> FindProfileAsync(int id)
    {
        var found = await context.Users.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x=> new UserProfileData()
            {
                Login = x.Login,
                Name = x.Name,
            }).FirstOrDefaultAsync();
        if (found == null)
        {
            return null;
        }
        return found;
    }

    public Task<UserEntity?> FindAsync(int id)
        => context.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task RegitserAsync(string login, string password)
    {
        var entity = new UserEntity()
        {
            Login = login,
            Password = password,
            Name = login
        };
        await context.Users.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }
}
