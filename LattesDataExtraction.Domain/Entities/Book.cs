﻿namespace LattesDataExtraction.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Origin { get; set; } = string.Empty;

        public DateOnly Year { get; set; }

        public string Language { get; set; } = string.Empty;

        public string PublisherCountry { get; set; } = string.Empty;

        public int NumberOfVolumes { get; set; }

        public int NumberOfPages { get; set; }

        public string PublisherCity { get; set; } = string.Empty;

        public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();
    }
}