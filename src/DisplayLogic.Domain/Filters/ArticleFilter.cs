namespace DisplayLogic.Domain.Filters;

public class ArticleFilter
{
    public List<Guid>? Ids { get; set; }
    public List<Guid>? TagIds { get; set; }
    public Guid? Id { get; set; }
}
