using System.IO;
using System.Threading.Tasks;

namespace ciftcidenEve
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}