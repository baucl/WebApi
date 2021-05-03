using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebApi.Core.Interfaces;
using WebApi.Core.Services;
using WebApi.Domain.Interfaces;
using WebApi.Infrastructure.DataAccess;
using WebApi.Infrastructure.Services.jsonplaceholder;

namespace WebApi.Web.Helpers
{
    public static class StartupHelpers
    {
        public static void AddServices(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            //DependencyInjection
            //Query
            services.AddScoped<IAutheticateService, AuthenticateService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IUserService, UserService>();
            //Command
            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();

            //Http Register
            //Query
            services.AddHttpClient<IAlbumsRepository, AlbumsRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["JPHBaseURL"]);
            });
            services.AddHttpClient<ICommentsRepository, CommentsRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["JPHBaseURL"]);
            });
            services.AddHttpClient<IAlbumsRepository, AlbumsRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["JPHBaseURL"]);
            });
            services.AddHttpClient<IPhotosRepository, PhotosRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["JPHBaseURL"]);
            });
            services.AddHttpClient<ITodosRepository, TodosRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["JPHBaseURL"]);
            });
            services.AddHttpClient<IUsersRepository, UsersRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["JPHBaseURL"]);
            });
            services.AddHttpClient<IPostsRepository, PostsRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["JPHBaseURL"]);
            });

            //Command


            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(optios =>
                {
                    optios.TokenValidationParameters = new TokenValidationParameters
                    {
                        RequireAudience = true,
                        ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Key,
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenAuthentication:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

        }
    }
}
