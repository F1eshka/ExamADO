﻿using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace EkzamenADO.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        // Включает режим "тестирования" — без реального создания BitmapImage
        public static bool TestMode { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string filename && !string.IsNullOrEmpty(filename))
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", filename);
                if (File.Exists(path))
                {
                    if (TestMode)
                        return path; // В режиме теста возвращаем путь вместо картинки

                    return new BitmapImage(new Uri(path));
                }
            }

            string defaultPath = "pack://application:,,,/Images/no-image.png";
            if (TestMode)
                return defaultPath;

            return new BitmapImage(new Uri(defaultPath));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
