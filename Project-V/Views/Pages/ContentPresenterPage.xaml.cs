using Microsoft.Maui.Hosting;
using Project_V.Controls;

namespace Project_V.Views.Pages;

public partial class ContentPresenterPage : ContentPage
{
    ControlTemplate tealTemplate;
    ControlTemplate aquaTemplate;

    public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(HeaderFooterPage), default(string));

    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    bool originalTemplate = true;
    public bool OriginalTemplate
    {
        get { return originalTemplate; }
    }
    public ContentPresenterPage()
	{
		InitializeComponent();
        Resources.MergedDictionaries.Add(new Project_V.Controls.TealTemplate());
        //tealTemplate = (ControlTemplate)Resources["TealTemplate"];
        //aquaTemplate = (ControlTemplate)Resources["AquaTemplate"];
        
    }
    void OnChangeThemeLabelTapped(object sender, EventArgs e)
    {
        originalTemplate = !originalTemplate;
        ControlTemplate = (originalTemplate) ? tealTemplate : aquaTemplate;
    }
}