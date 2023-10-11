using Project_V.Properties.Interface;

//[assembly: Dependency(typeof(ControlHeightService))]
namespace Project_V.Properties.Views
{
    public class ControlHeightService : IControlHeightService
    {
        public double GetControlHeight(string controlId)
        {
            throw new NotImplementedException();
        }


        //public ControlHeightService(object yourPage)
        //{
        //    YourPage = yourPage;
        //}

        //public double GetControlHeight(string controlId)
        //{
        //    var control = YourPlatformSpecificMethodToGetControl(controlId);

        //    return control.Height;
        //}

        //private YourControlType YourPlatformSpecificMethodToGetControl(string controlId)
        //{
        //    // 在Android中，使用FindViewById方法根据控件的AutomationId获取相应的控件，并进行强制转换
        //    return Android.Views.YourPage.FindViewById<YourControlType>(YourResourceIdFromControlAutomationId(controlId));
        //}

        //private object YourResourceIdFromControlAutomationId(string controlId)
        //{
        //    throw new NotImplementedException();
        //}

        //private int YourResourceIdFromControlAutomationId(string controlId)
        //{
        //    // 在Android中，使用Resources.GetIdentifier方法根据AutomationId返回资源ID
        //    // 根据需要进行实现
        //}

        private class YourControlType
        {
            public double Height { get; internal set; }
        }
    }
}
