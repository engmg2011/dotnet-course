using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBackend.Service.IService;

public interface IFileUpload
{
    Task<string> UploadFile(IBrowserFile file);

    bool DeleteFile(string filePath);
}