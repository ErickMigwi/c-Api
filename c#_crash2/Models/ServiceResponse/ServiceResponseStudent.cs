namespace c__crash2.Models.ServiceResponse
{
    public class ServiceResponseStudent<T>
    {
        public T? Data {  get; set; }
        public string Message { get; set; } = "";
        public bool Success { get; set; } = true;
    }
}
