
using HobbiesAPI.Data;
using HobbiesAPI.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace HobbiesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //Get all people
            app.MapGet("/people", async (ApplicationDbContext context) =>
            {
                var people = await context.Peoples.Include(h => h.HobbyEnrollments).ToListAsync();
                if (people == null)
                {
                    return Results.NotFound("Hittade inga personer");
                }

                return Results.Ok(people);
            });

            //Create people
            app.MapPost("/people", async (People people, ApplicationDbContext context) =>
            {
                context.Peoples.Add(people);
                await context.SaveChangesAsync();
                return Results.Created($"/people/{people.PeopleId}", people);
            });

            //Get people by id
            app.MapGet("/people/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var people = await context.Peoples
                        .Include(e => e.HobbyEnrollments)
                            .ThenInclude(h => h.Hobby)
                        .FirstOrDefaultAsync(p => p.PeopleId == id);

                if (people == null)
                {
                    return Results.NotFound("Ingen person hittades");
                }
                return Results.Ok(people);
            });

            //Get all hobbies
            app.MapGet("/hobby", async (ApplicationDbContext context) =>
            {
                var hobbies = await context.Hobbies.ToListAsync();
                if (hobbies == null)
                {
                    return Results.NotFound("Hittade inga hobbys");
                }
                return Results.Ok(hobbies);
            });

            //Create hobbies
            app.MapPost("/hobby", async (Hobby hobby, ApplicationDbContext context) =>
            {
                context.Hobbies.Add(hobby);
                await context.SaveChangesAsync();
                return Results.Created($"/people/{hobby.HobbyId}", hobby);
            });

            //Get all hobbies enrollment
            app.MapGet("/hobbyenrollment", async (ApplicationDbContext context) =>
            {
                var hobbyEnrollment = await context.HobbyEnrollments.ToListAsync();
                if (hobbyEnrollment == null)
                {
                    return Results.NotFound("Hittade inga hobby registreringar");
                }
                return Results.Ok(hobbyEnrollment);
            });

            //Create hobbies enrollment
            app.MapPost("/hobbyenrollment", async (HobbyEnrollment hobbyEnrollment, ApplicationDbContext context) =>
            {
                //Finding person and hobby for the hobbyEnrollment 
                var person = await context.Peoples.FindAsync(hobbyEnrollment.FKPeopleId);
                var hobby = await context.Hobbies.FindAsync(hobbyEnrollment.FKHobbyId);

                context.HobbyEnrollments.Add(hobbyEnrollment);

                //Adding the hobbyEnrollment to a person and a hobby
                person.HobbyEnrollments.Add(hobbyEnrollment);
                hobby.HobbyEnrollments.Add(hobbyEnrollment);
                await context.SaveChangesAsync();

                return Results.Created($"/hobbyenrollment/{hobbyEnrollment.Id}", hobbyEnrollment);
            });

            //Adding links for a hobbyenrollment
            app.MapPost("hobbyenrollment{id:int}/links", async(int id, string updatedLink, ApplicationDbContext context) =>
            {
                var hobbyEnrollment = await context.HobbyEnrollments.FindAsync(id);
                if (hobbyEnrollment == null)
                {
                    return Results.NotFound("Hittade ingen hobbyregistrering");
                }
                //Creates a new list of links if its null 
                if (hobbyEnrollment.Links == null)
                {
                    hobbyEnrollment.Links = new List<string>();
                }

                hobbyEnrollment.Links.Add(updatedLink);

                await context.SaveChangesAsync();
                return Results.Created($"/hobbyenrollment/{id}/links", updatedLink);
            });

            app.Run();
        }
    }
}
