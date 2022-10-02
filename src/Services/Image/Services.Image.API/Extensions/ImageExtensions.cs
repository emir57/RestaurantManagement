using Services.Image.API.Messages;

namespace Services.Image.API.Extensions;

public static class ImageExtensions
{
    public static ValueTask<(bool result, string message)> UploadAsync(this IFormFile formFile, string imagePath, string productId)
    {
        if (formFile == null && formFile.Length <= 0)
            return new ValueTask<(bool result, string message)>((false, ImageMessages.ImageNotFound));

        string extension = Path.GetExtension(formFile.FileName);
        if (extension != ".png")
            return new ValueTask<(bool result, string message)>((false, ImageMessages.InvaidImageType));

        string newFileName = uploadAsync(formFile, productId, imagePath, extension).GetAwaiter().GetResult();

        string returnPath = string.Format("Images/{0}", newFileName);
        return new ValueTask<(bool result, string message)>((true, returnPath));
    }

    public static ValueTask<(bool result, string message)> DeleteAsync(this string productId, string imagePath)
    {
        string fileName = $"{productId}.png";
        string path = Path.Combine(imagePath, fileName);

        if (File.Exists(path) == false)
            return new ValueTask<(bool result, string message)>((false, ImageMessages.ImageNotFound));

        File.Delete(path);
        return new ValueTask<(bool result, string message)>((true, string.Empty));
    }

    public static ValueTask<(bool result, string message)> GetAsync(this string productId, string imagePath)
    {
        string fileName = $"{productId}.png";
        var path = Path.Combine(imagePath, fileName);

        if (File.Exists(path) == false)
            return new ValueTask<(bool result, string message)>((false, ImageMessages.ImageNotFound));

        string url = $"http://localhost:5014/Images/{productId}.png";
        return new ValueTask<(bool result, string message)>((true, url));
    }

    private async static Task<string> uploadAsync(IFormFile image, string productId, string imagePath, string extension, CancellationToken cancellationToken = default)
    {
        string newFileName = string.Format("{0}{1}", productId, extension);
        string path = Path.Combine(imagePath, newFileName);

        if (Directory.Exists(imagePath) == false)
            Directory.CreateDirectory(imagePath);

        using var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream, cancellationToken);
        await stream.FlushAsync();

        return newFileName;
    }
}
