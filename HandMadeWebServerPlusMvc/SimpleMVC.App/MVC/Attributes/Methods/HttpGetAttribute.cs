namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod == "GET")
            {
                return true;
            }
            return false;
        }
    }
}
