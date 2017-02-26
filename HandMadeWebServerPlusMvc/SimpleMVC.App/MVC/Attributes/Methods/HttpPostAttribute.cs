namespace SimpleMVC.App.MVC.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if (requestMethod == "POST")
            {
                return true;
            }

            return false;
        }
    }
}
