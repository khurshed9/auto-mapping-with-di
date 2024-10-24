
using auto_mapper_testing.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DTO_Pagination_Filtering_Mapping;

[ApiController]
[Route("/api/users")]
public sealed class UserController(IUserRepository userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers([FromQuery] UserFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ReadUserDTO>>>.Success(null!,
            userService.GetAllUsers(filter)));

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        ReadUserDTO? res = userService.GetUserById(id);
        return res != null
            ? Ok(ApiResponse<ReadUserDTO?>.Success(null!, res))
            : NotFound(ApiResponse<ReadUserDTO?>.Fail(null!, null));
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDTO createUserDTO)
    {
        bool res = userService.CreateUser(createUserDTO);
        return res
            ? Ok(ApiResponse<bool>.Success(null!, res))
            : BadRequest(ApiResponse<bool>.Fail(null!, res));
    }

    [HttpPut]
    public IActionResult UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
    {
        bool res = userService.UpdateUser(updateUserDTO);
        return res
            ? Ok(ApiResponse<bool>.Success(null!, res))
            : NotFound(ApiResponse<bool>.Fail(null!, res));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        bool res = userService.DeleteUser(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null!, res))
            : NotFound(ApiResponse<bool>.Fail(null!, res));
    }
}
