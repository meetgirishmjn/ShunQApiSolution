using System;

namespace xApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class ServiceItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }

    public class AppItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}