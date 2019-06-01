using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Function
{
    /// <summary>
    /// A Ideas model.
    /// </summary>
    public class IdeasModel
    {
        /// <summary>
        /// Gets or sets the ideas.
        /// </summary>
        public IEnumerable<IdeaModel> ideas { get; set; }
    }
}