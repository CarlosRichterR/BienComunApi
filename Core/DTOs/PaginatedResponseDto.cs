namespace BienComun.Core.DTOs;

public class PaginatedResponseDto<T>
{
    public int TotalCount { get; set; } // Número total de elementos disponibles en la fuente de datos
    public IEnumerable<T> Items { get; set; } = new List<T>(); // Lista de elementos en la página actual
}
