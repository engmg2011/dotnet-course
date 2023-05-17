using Microsoft.JSInterop;
namespace WebAssemplyApp.Helpers;


public static class SwalCS
{ 
 
    public static async Task Swal( this IJSRuntime _jsRuntime,string type, string message)
    {
        await _jsRuntime.InvokeVoidAsync("swal", message);
        
    }
}
