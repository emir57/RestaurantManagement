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
