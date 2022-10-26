using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContactApp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactApp.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace ContactApp.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement== null)
            {
                var gradientDrawable = new GradientDrawable();                
                gradientDrawable.SetCornerRadius(0f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.LightGray);
                gradientDrawable.SetColor(Android.Graphics.Color.White);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);

            }
        }
    }
}