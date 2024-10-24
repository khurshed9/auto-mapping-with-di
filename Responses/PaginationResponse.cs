public record PaginationResponse<T>:BaseFilter
{
    public int TotalRecords{get; init;}
    public int TotalPages{get; init;}
    public T? Data{get; init;}

    private PaginationResponse(int pageNumber, int pageSize, int totalRecords, T data):base(pageNumber, pageSize)
    {
        this.Data=data;
        this.TotalRecords=totalRecords;
        this.TotalPages=(int)Math.Ceiling((double)totalRecords/pageSize);
    }

    public static PaginationResponse<T> Create(int pageNumber, int pageSize, int totalRecords, T data)
    => new PaginationResponse<T>(pageNumber, pageSize, totalRecords, data);
}