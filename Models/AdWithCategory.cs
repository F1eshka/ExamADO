﻿namespace EkzamenADO.Models
{
    public class AdWithCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }           
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }    
        public string ImageFileName { get; set; }   
    }

}
