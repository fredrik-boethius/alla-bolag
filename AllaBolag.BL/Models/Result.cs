namespace AllaBolag.BL.Models
{
    public class Result<T> where T : class
    {
        public T Object { get; set; }
        public bool Success
        {
            get
            {
                return Object != null ? true : false;
            }
        }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Message: {Message} | Object: {(object)Object ?? "null"} | Success: {Success}";
        }

    }

}
