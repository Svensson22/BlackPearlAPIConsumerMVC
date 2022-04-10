using Microsoft.EntityFrameworkCore;
using SeidoDbWebApiConsumerMVC.Services;

namespace SeidoDb.Web
{
	public class Startup
	{
		public Startup()
		{
		}
		public void ConfigureServices(IServiceCollection services)
        {
			services.AddRazorPages();           //Enables Razorpages
			services.AddScoped<ISeidoDbHttpService, SeidoDbHttpService>();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			if (!env.IsDevelopment())
			{
				app.UseHsts();
			}

			app.UseRouting();
			app.UseHttpsRedirection();
			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseEndpoints(endpoint =>
			{
				endpoint.MapRazorPages();		//Enables Razorpages.
			});
		}
	}
}

