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

                CopyFilesRecursively(BaseImages, CharacterImages);
            };
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            //foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            //{
            //    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            //}

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
