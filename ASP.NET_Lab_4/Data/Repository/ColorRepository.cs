﻿using ASP.NET_Lab_4.Data.Interfaces;
using ASP.NET_Lab_4.Data.Models;

namespace ASP.NET_Lab_4.Data.Repository
{
    public class ColorRepository : IClothesColor
    {
        private readonly AppDBContent appDBContent;
        public ColorRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Color> AllColors => appDBContent.Color;
    }
}
