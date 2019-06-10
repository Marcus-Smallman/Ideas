using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Function
{
    /// <summary>
    /// A Idea model.
    /// </summary>
    public class IdeaModel
    {
        /// <summary>
        /// Gets or sets the id of the idea.
        /// </summary>
        [BsonId]
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the idea.
        /// </summary>
        public string idea { get; set; }

        /// <summary>
        /// Gets or sets the time the idea was created.
        /// </summary>
        public DateTime? createdUtc { get; set; }
    }
}