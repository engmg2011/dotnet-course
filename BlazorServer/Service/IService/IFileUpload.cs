using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServer.Service.IService;

public interface IFileUpload
{
    Task<string> UploadFile(IBrowserFile file);

    bool DeleteFile(string filePath);
}