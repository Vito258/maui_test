using Android.Content;
using Android.Content.Res;
using Android.Database;
using Debug = System.Diagnostics.Debug;
using Uri = Android.Net.Uri;

namespace Project_V.Platforms.Android
{

    //资源视频文件存储在包的 assets 文件夹中，需要内容提供商才能访问它。 内容提供程序由 VideoProvider 类提供，
    //类创建一个 AssetFileDescriptor 对象，该对象提供对视频文件的访问权限：
    [ContentProvider(new string[] { "com.companyname.videodemos" })]
    public class VideoProvider : ContentProvider
    {
        public override AssetFileDescriptor OpenAssetFile(Uri uri, string mode)
        {
            var assets = Context.Assets;
            string fileName = uri.LastPathSegment;
            if (fileName == null)
                throw new FileNotFoundException();

            AssetFileDescriptor afd = null;     // AssetFileDescriptor 对象，该对象提供对视频文件的访问权限
            try
            {
                afd = assets.OpenFd(fileName);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex);
            }
            return afd;
        }

        public override bool OnCreate()
        {
            return false;
        }

        public override int Delete(Uri uri, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }

        public override string GetType(Uri uri)
        {
            throw new NotImplementedException();
        }

        public override Uri Insert(Uri uri, ContentValues values)
        {
            throw new NotImplementedException();
        }

        public override ICursor Query(Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public override int Update(Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }
    }
}
