namespace RepositoryEntityFrameworkSqlServer.Entities.Constants
{
    internal interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
