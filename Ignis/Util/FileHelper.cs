using Ignis.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace Ignis.Util
{
    public class FileHelper
    {
        public static bool CheckIfFileIsImage(HttpPostedFileBase image, out string error)
        {
            if (image == null)
            {
                error = "Please upload an images";
                return false;
            }

            if (image.ContentType.ToLower() != "image/jpg" &&
                image.ContentType.ToLower() != "image/jpeg" &&
                image.ContentType.ToLower() != "image/pjpeg" &&
                image.ContentType.ToLower() != "image/gif" &&
                image.ContentType.ToLower() != "image/x-png" &&
                image.ContentType.ToLower() != "image/png")
            {
                error = "Please upload images only";
                return false;
            }

            if (Path.GetExtension(image.FileName).ToLower() != ".jpg"
                && Path.GetExtension(image.FileName).ToLower() != ".png"
                && Path.GetExtension(image.FileName).ToLower() != ".gif"
                && Path.GetExtension(image.FileName).ToLower() != ".jpeg")
            {
                error = "Please upload images only";
                return false;
            }

            error = "";
            return true;
        }

        public static void SaveFiles(IEnumerable<HttpPostedFileBase> image, string basePath)
        {
            for (int i = 0; i < 4; i++)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(image.ToList()[i].FileName);
                System.Threading.Thread.Sleep(5);
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                image.ToList()[i].SaveAs(Path.Combine(basePath, fileName));
            }
        }

        public static List<ImageViewModel> GetImages(string id, string basePath)
        {
            List<ImageViewModel> images = new List<ImageViewModel>();
            string[] files = Directory.GetFiles(basePath);
            foreach (var file in files)
            {
                try
                {
                    images.Add(new ImageViewModel
                    {
                        FilePath = id + "/" + Path.GetFileName(file),
                        Description = DateTime.ParseExact(Path.GetFileNameWithoutExtension(file),
                            "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture).ToLongDateString()
                    });
                }
                catch (FormatException)
                {
                    continue;
                }
            }

            return images;
        }
    }
}