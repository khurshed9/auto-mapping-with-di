public record BaseFilter
{
    public int PageNumber{get; set;}
    public int PageSize{get; set;}

    public BaseFilter()
    {
        this.PageNumber=1;
        this.PageSize=5;
    }
    public BaseFilter(int pageNumber, int pageSize)
    {
        if(pageNumber<=0) this.PageNumber=1;
        this.PageNumber=pageNumber;
        if(pageSize<=0) this.PageSize=5;
        this.PageSize=pageSize;
    }
}