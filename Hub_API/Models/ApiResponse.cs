using Application.Helpers;
using Domain.Helpers;

namespace CleanArch.Api.Models
{
    public class ApiResponse<T> 
    {
        public bool Success { get; set; }
        
        public string Message { get; set; } = default!;
        public T Result { get; set; } = default!;
        public BasePage? pageinfo { get; set; }
    }
}
