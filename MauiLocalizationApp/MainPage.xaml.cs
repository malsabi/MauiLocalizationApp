using System.Globalization;
using MauiLocalizationApp.Resources.Languages;

namespace MauiLocalizationApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ChangeLanguageButtonClicked(object sender, EventArgs e)
        {
            if (AppResources.Culture.TwoLetterISOLanguageName.Equals("en"))
            {
                ChangeDirection.Instance.SetFlowDirection(FlowDirection.RightToLeft);
                LocalizationResourceManager.Instance.SetCulture(new CultureInfo("ar"));
            }
            else
            {
                ChangeDirection.Instance.SetFlowDirection(FlowDirection.LeftToRight);
                LocalizationResourceManager.Instance.SetCulture(new CultureInfo("en"));
            }
        }
    }
}