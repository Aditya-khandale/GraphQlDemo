using GraphQLDemo.API.Mutation;
using GraphQLDemo.API.Schema;
using GraphQLDemo.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));
var app = builder.Build();


//app.MapGet("/", () => "Hello World!");
app.MapGraphQL();


app.Run();

