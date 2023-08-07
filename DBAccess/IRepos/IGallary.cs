using DBAccess.ViewModels;

namespace DBAccess.IRepos
{
    public interface IGallary
    {
        ApiResponse SetGallaryPhotos(GallaryViewModel gallaries);
        ApiResponse GetGallaryPhotos(string groupName);
        
    }
}
