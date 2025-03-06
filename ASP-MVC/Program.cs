using Common.Repositories;

namespace ASP_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			//Personalized Services
				//Student
				builder.Services.AddScoped<IStudentRepository<DAL.Entities.Student>, DAL.Services.StudentService>();
				builder.Services.AddScoped<IStudentRepository<BLL.Entities.Student>, BLL.Services.StudentService>();
				//Section
				builder.Services.AddScoped<ISectionRepository<DAL.Entities.Section>, DAL.Services.SectionService>();
				builder.Services.AddScoped<ISectionRepository<BLL.Entities.Section>, BLL.Services.SectionService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
