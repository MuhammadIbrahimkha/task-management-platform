using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.IntegrationTests.Persistence;

public class ApplicationDbContextTests
{
    [Fact]
    public void Model_MapsTaskItemToSqlServerTableWithDomainConstraints()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=TaskManagement;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

        using var context = new ApplicationDbContext(options);
        var entity = context.Model.FindEntityType(typeof(TaskItem));

        Assert.NotNull(entity);
        Assert.Equal("TaskItems", entity.GetTableName());
        Assert.Equal(200, entity.FindProperty(nameof(TaskItem.Title))!.GetMaxLength());
        Assert.True(entity.FindProperty(nameof(TaskItem.Title))!.IsNullable is false);
        Assert.Equal(2000, entity.FindProperty(nameof(TaskItem.Description))!.GetMaxLength());
        Assert.True(entity.FindProperty(nameof(TaskItem.Description))!.IsNullable);
        Assert.True(entity.FindProperty(nameof(TaskItem.DueDate))!.IsNullable);
        Assert.True(entity.FindProperty(nameof(TaskItem.Status))!.IsNullable is false);
        Assert.True(entity.FindProperty(nameof(TaskItem.Priority))!.IsNullable is false);
        Assert.True(entity.FindProperty(nameof(TaskItem.CreatedAtUtc))!.IsNullable is false);
        Assert.True(entity.FindProperty(nameof(TaskItem.UpdatedAtUtc))!.IsNullable is false);
        Assert.Equal("int", entity.FindProperty(nameof(TaskItem.Status))!.GetColumnType());
        Assert.Equal("int", entity.FindProperty(nameof(TaskItem.Priority))!.GetColumnType());
    }

    [Fact]
    public void AddInfrastructure_RegistersSqlServerContextFromConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:DefaultConnection"] =
                    "Server=(localdb)\\MSSQLLocalDB;Database=TaskManagementTest;Trusted_Connection=True;TrustServerCertificate=True"
            })
            .Build();

        var services = new ServiceCollection();
        services.AddInfrastructure(configuration);

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        Assert.Equal("Microsoft.EntityFrameworkCore.SqlServer", context.Database.ProviderName);
    }

    [Fact]
    public void AddInfrastructure_ThrowsWhenConnectionStringIsMissing()
    {
        var configuration = new ConfigurationBuilder().Build();
        var services = new ServiceCollection();

        var exception = Assert.Throws<InvalidOperationException>(
            () => services.AddInfrastructure(configuration));

        Assert.Contains("DefaultConnection", exception.Message, StringComparison.Ordinal);
    }
}
