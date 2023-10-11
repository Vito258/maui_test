using System.ComponentModel;

namespace Project_V.Models
{
    public class ImageControlModel : INotifyPropertyChanged
    {
        private readonly List<string> imagePaths;
        private int currentIndex;
        private string imageSource;
        public ImageControlModel()
        {
            // 初始化图片路径数组，并设置当前索引为0
            imagePaths = new List<string> {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg",
            "image4.jpg" };
            currentIndex = 0;

            // 设置初始图片源
            ImageSource = imagePaths[currentIndex];
        }

        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public List<string> ImagePaths
        {
            get { return ImagePaths; }
            set
            {
                ImagePaths = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowImage()
        {

            currentIndex = (currentIndex + 1) % imagePaths.Count;
            ImageSource = imagePaths[currentIndex];
        }

        public void SwitchToNextImage()
        {
            currentIndex++;
            if (currentIndex >= imagePaths.Count)
            {
                currentIndex = 0;
            }
            ImageSource = imagePaths[currentIndex];

        }
        public void SwitchToLastImage()
        {

            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = imagePaths.Count - 1;
            }
            ImageSource = imagePaths[currentIndex];
        }

    }
}
