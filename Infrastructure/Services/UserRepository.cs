
using auto_mapper_testing.DTOs;
using AutoMapper;

public class UserRepository(UserDbContext userDbContext, IMapper mapper) : IUserRepository
{
    public bool CreateUser(CreateUserDTO createUserDTO)
    {
        try
        {
            bool isExited = userDbContext.Users.Any(x => x.Name == createUserDTO.Name && x.IsDeleted == false);
            if (isExited) return false;
            userDbContext.Users.Add(mapper.Map<User>(createUserDTO));
            userDbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool DeleteUser(int id)
    {
        try
        {
            User? user = userDbContext.Users.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (user == null) return false;

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            userDbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public PaginationResponse<IEnumerable<ReadUserDTO>> GetAllUsers(UserFilter filter)
    {
        IQueryable<User> courses = userDbContext.Users.Where(x=>x.IsDeleted==false);
        if (filter.Name != null)
            courses = courses.Where(x => x.Name.ToLower()
                .Contains(filter.Name.ToLower()));
        

        IQueryable<User> result = courses.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize);



        IEnumerable<ReadUserDTO> res = mapper.Map<IEnumerable<ReadUserDTO>>(result);

        int totalRecords = userDbContext.Users.Where(x=>x.IsDeleted==false).Count();
        return PaginationResponse<IEnumerable<ReadUserDTO>>.Create(filter.PageNumber, filter.PageSize, totalRecords,
            res);
    }


    public ReadUserDTO? GetUserById(int id)
    {
        try
        {
            User? user = userDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return null;
            return mapper.Map<ReadUserDTO>(user);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }

    public bool UpdateUser(UpdateUserDTO updateUserDTO)
    {
        try
        {
            User? user = userDbContext.Users.FirstOrDefault(x => x.Id == updateUserDTO.Id && x.IsDeleted == false);
            if (user == null) return false;

            mapper.Map(updateUserDTO, user);
            userDbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }
}