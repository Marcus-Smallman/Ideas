namespace Function
{
    /// <summary>
    /// A Response model.
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Gets or sets an object that represents the http response.
        /// </summary>
        public object response { get; set; }

        /// <summary>
        /// Gets or sets an integer that represents the http response status code.
        /// </summary>
        public int status { get; set; }
    }
}