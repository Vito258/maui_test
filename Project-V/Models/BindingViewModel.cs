using Project_V.Models.Domains;
using System.ComponentModel;

namespace Project_V.Models;

//实现了一种通知机制，该机制允许绑定基础结构在属性值更改时收到通知。 此通知机制是 INotifyPropertyChanged 接口，
//该接口定义名为 PropertyChanged 的单个事件。 实现此接口的类通常在其公共属性之一更改值时触发 事件。 如果属性永远不会更改，则无需引发 事件。
public class BindingViewModel : INotifyPropertyChanged
{
    Color color;
    string name;
    float hue;              //色调
    float saturation;       //饱和度
    float luminosity;       //光度

    public event PropertyChangedEventHandler PropertyChanged;

    public float Hue
    {
        get
        {
            return hue;
        }
        set
        {
            if (hue != value)
            {
                Color = Color.FromHsla(value, saturation, luminosity);
            }
        }
    }

    public float Saturation
    {
        get
        {
            return saturation;
        }
        set
        {
            if (saturation != value)
            {
                Color = Color.FromHsla(hue, value, luminosity);
            }
        }
    }

    public float Luminosity
    {
        get
        {
            return luminosity;
        }
        set
        {
            if (luminosity != value)
            {
                Color = Color.FromHsla(hue, saturation, value);
            }
        }
    }

    public Color Color
    {
        get
        {
            return color;
        }
        set
        {
            if (color != value)
            {
                color = value;
                hue = color.GetHue();
                saturation = color.GetSaturation();
                luminosity = color.GetLuminosity();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Saturation"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Luminosity"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));

                Name = NamedColor.GetNearestColorName(color);
            }
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (name != value)
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
    }
}