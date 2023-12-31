using MedUnify.WebUI;
using MedUnify.WebUI.Repository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7228/api/") });
builder.Services.AddScoped<IPatientHttpRepository, PatientHttpRepository>();
await builder.Build().RunAsync();
