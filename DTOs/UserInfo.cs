namespace auto_mapper_testing.DTOs;

public readonly record struct UpdateUserDTO(
    int Id,
    string Name,
    string Email
);

public readonly record struct ReadUserDTO(
    int Id,
    string Name,
    string Email
);

public readonly record struct CreateUserDTO
(
    string Name,
    string Email
);