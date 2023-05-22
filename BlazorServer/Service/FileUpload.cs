using BlazorServer.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorCommon;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileUpload( IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    public async Task<string> UploadFile(IBrowserFile file)
    {
        FileInfo fileInfo = new FileInfo(file.Name);
        var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
        var folderDirectory = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "images", "product");
        // var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\product";
        if (!Directory.Exists(folderDirectory))
        {
            Directory.CreateDirectory(folderDirectory);
        }

        var filePath = Path.Combine(folderDirectory, fileName);

        await using FileStream fs = new FileStream(filePath, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(fs);
        return $"images/product/{fileName}";
    }

    public bool DeleteFile(string filePath)
    {
        if(File.Exists(_webHostEnvironment.WebRootPath+filePath))
        {
            File.Delete(_webHostEnvironment.WebRootPath + filePath);
            return true;
        }

        return false;
    }

}