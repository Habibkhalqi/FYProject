namespace KotliEstate.Service;

public static class Helper
{
    public static void DeleteImage(string imagename, string folderpath, IWebHostEnvironment env)
    {
        string ImageName = imagename;
        var FolderPath = Path.Combine(env.WebRootPath, $"uploaded_image/{folderpath}");
        var imagePath = Path.Combine(FolderPath, ImageName);
        FileInfo ImageFile = new FileInfo(imagePath);
        if (ImageFile.Exists)
        {
            ImageFile.Delete();
        }
        
    }
    
    /// <summary>
    /// this function work to upload image in your projects
    /// </summary>
    /// <param name="imagename">Provide the image name </param>
    /// <param name="folderpath">Provide the path of the folder in which you want to save the iamge </param>
    /// <param name="env">inject the IWebHostEnvironment and pass parameter here</param>
    /// <returns>it will istreamclass object</returns>
    public  static FileStream UploadImage(string imagename, string folderpath, IWebHostEnvironment env)
    {
        string ImageName = imagename;
        var FolderPath = Path.Combine(env.WebRootPath, $"uploaded_image/{folderpath}");
        var imagePath = Path.Combine(FolderPath, ImageName);
        
        var ImageUploadStream = new FileStream(imagePath, FileMode.Create);
        return ImageUploadStream;

    }
}