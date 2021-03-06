﻿using System;
using Xamarin.Forms;

namespace CANADA.CustomControl
{
    public class ExtendedViewCell :  ViewCell
    {
        public ExtendedViewCell()
        {
        }
        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create("SelectedBackgroundColor",
                                    typeof(Color),
                                    typeof(ExtendedViewCell),
                                    Color.Default);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

    }
}
