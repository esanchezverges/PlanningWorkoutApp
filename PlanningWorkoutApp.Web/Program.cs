using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlanningWorkoutApp.Web;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddRadzenComponents();

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://esanchezverges.github.io/PlanningWorkoutApp/") }
);

await builder.Build().RunAsync();
