using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemplyApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// WebAssemplyApp.Program.Main();
await builder.Build().RunAsync();

//
// namespace WebAssemplyApp
// {
//     class Program
//     {
//         public static void Main()
//         {
//             Console.WriteLine("hello Gemy 2, How are you ?");
//             
//         }
//     }
// }
