namespace TestTaskIIcoServer.Exceptions
{
    public class UserByIdNotFoundException : Exception
    {
        public UserByIdNotFoundException(string message)
        {
            Console.WriteLine(message);
        }
    }
}