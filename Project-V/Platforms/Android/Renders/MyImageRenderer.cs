using Android.Content;
using Android.Gms.Common.Apis;
using Android.Graphics;
using Java.Util.Streams;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Project_V.Platforms.Android.Renders;
using System.IO.IsolatedStorage;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Android.Net;
using CancellationToken = System.Threading.CancellationToken;
using Stream = System.IO.Stream;

//[assembly: ExportImageSourceHandler(typeof(UriImageSource), typeof(MyImageLoaderSourceHandler))]
namespace Project_V.Platforms.Android.Renders
{
    //读取UriImageSource的ImageHandler
    public class MyImageLoaderSourceHandler : IImageSourceHandler
    {
        static readonly IsolatedStorageFile MyStore = IsolatedStorageFile.GetUserStoreForApplication();
        internal const string CacheName = "ImageLoaderCache";
        private TimeSpan CacheTime = new TimeSpan(5, 0, 0, 0);

        public async Task<Bitmap> LoadImageAsync(ImageSource imagesource, Context context, CancellationToken cancelationToken = default(CancellationToken))
        {
            var imageLoader = imagesource as UriImageSource;
            Bitmap bitmap = null;
            using (Stream imageStream = await GetStreamAsync(imageLoader.Uri,cancelationToken).ConfigureAwait(false))
            {
                bitmap = await BitmapFactory.DecodeStreamAsync(imageStream).ConfigureAwait(false);
            }
            if (bitmap == null)
            { 
                bitmap = await BitmapFactory.DecodeResourceAsync(context.Resources, Resource.Drawable.noimage);
            }
            return bitmap;
        }
        async Task<Stream> GetStreamAsyncUnchecked(string key, Uri uri, TimeSpan cacheValidity, CancellationToken cancellationToken)
        {
           
                Stream stream;
                    stream = await GetStreamAsync(uri, cancellationToken).ConfigureAwait(false);
                    if (stream == null)
                        return null;
                return stream;
        }

        public async Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            HttpClient client = null;
            try
            {
                client = new HttpClient(new AndroidMessageHandler());
                response = await client.GetAsync(uri, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                client?.Dispose();
                response?.Dispose();
                return null;
            }
        }
    }
}