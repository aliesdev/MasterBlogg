using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
builder.Services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
builder.Services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
builder.Services.AddTransient<IArticleApplication, ArticleApplication>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<IArticleValidatorService, ArticleValidatorService>();
builder.Services.AddTransient<IArticleQuery, ArticleQuery>();


var connectionString = builder.Configuration.GetConnectionString("MasterBlogger");
builder.Services.AddDbContext<MasterBlogContext>(x => x.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
