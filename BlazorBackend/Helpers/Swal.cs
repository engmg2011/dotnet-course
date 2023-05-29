using Microsoft.JSInterop;

namespace BlazorBackend.Helpers;


public static class SwalCS
{ 
 
    public static async Task Swal( this IJSRuntime _jsRuntime,string type, string title, string? message = "")
    {
        await _jsRuntime.InvokeVoidAsync("NSwal" ,
            " { \"icon\": \""+type+"\" , \"title\": \""+title+"\", \"message\": \""+message+"\" }"
        );
    }
}
