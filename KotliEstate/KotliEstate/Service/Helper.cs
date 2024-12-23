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
}