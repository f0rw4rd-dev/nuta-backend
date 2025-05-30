using Nuta.Backend.BuildingBlocks.Application.Structs;
using Nuta.Backend.Users.Domain.ValueObjects;

namespace Nuta.Backend.Users.Application.Models.Requests;

public record UpdateUserRequest(Optional<string> Name, Optional<FoodPreferences> FoodPreferences);