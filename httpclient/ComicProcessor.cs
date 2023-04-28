using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace httpclient
{
    public class ComicProcessor
    {

        public static async Task<ComicModel> LoadComic(int comicNumber=0)
        {
            string url = "";
            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            }
            else
            {
                url = $"https://xkcd.com/info.0.json";
            }

            using (HttpResponseMessage response = await ApiHelper.Apiclient.GetAsync(url)) 
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //loading image from website
        private  async Task<BitmapImage> LoadImage()
        {
            var comic = await LoadComic();
            var uriSournce = new Uri(comic.Img,UriKind.Absolute);
            var img = new BitmapImage(uriSournce);
            return img;
        }
    }
} 
