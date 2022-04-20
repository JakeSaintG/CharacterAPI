using System.IO;

namespace CharacterAPI.Services
{
    public class ImageService
    {
        static readonly string BaseImages = "Images/ImgBaseData";
        static readonly string CharacterImages = "Images/CharacterImgs";

        public static void CharacterFolderCheck()
        {
            if (!Directory.Exists(CharacterImages))
            {
                Directory.CreateDirectory(CharacterImages);

                CopyImageFiles(BaseImages, CharacterImages);
            };
        }

        private static void CopyImageFiles(string sourcePath, string targetPath)
        {
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
