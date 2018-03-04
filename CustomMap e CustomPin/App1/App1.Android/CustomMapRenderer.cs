using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1;
using App1.Droid.CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace App1.Droid
{
    
namespace CustomRenderer.Droid
    {
        public class CustomMapRenderer : MapRenderer, Android.Gms.Maps.GoogleMap.IInfoWindowAdapter
        {
            List<CustomPin> customPins;

            public CustomMapRenderer(Context context) : base(context)
            {
            }

            protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement != null)
                {
                    NativeMap.InfoWindowClick -= OnInfoWindowClick;
                }

                if (e.NewElement != null)
                {
                    var formsMap = (CustomMap)e.NewElement;
                    customPins = formsMap.CustomPins;
                    Control.GetMapAsync(this);
                }
            }

            protected override void OnMapReady(GoogleMap map)
            {
                base.OnMapReady(map);

                NativeMap.InfoWindowClick += OnInfoWindowClick;
                NativeMap.SetInfoWindowAdapter(this);
            }

            protected override MarkerOptions CreateMarker(Pin pin)
            {
                var marker = new MarkerOptions();
                marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                marker.SetTitle(pin.Label);
                marker.SetSnippet(pin.Address);
                marker.SetIcon(GetCustomBitmapDescriptor("#8e24aa"));
                return marker;
            }

            private BitmapDescriptor GetCustomBitmapDescriptor(string text)
            {
                using (Paint paint = new Paint(PaintFlags.AntiAlias))
                {
                    using (Rect bounds = new Rect())
                    {
                        using (Bitmap baseBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.Pin8))
                        {

                            Bitmap resultBitmap = Bitmap.CreateBitmap(baseBitmap, 0, 0, baseBitmap.Width - 1, baseBitmap.Height - 1);
                            Paint p = new Paint();
                            ColorFilter filter = new PorterDuffColorFilter(Android.Graphics.Color.ParseColor(text), PorterDuff.Mode.SrcAtop);
                            p.SetColorFilter(filter);
                            Canvas canvas = new Canvas(resultBitmap);
                            canvas.DrawBitmap(resultBitmap, 0, 0, p);
                            Bitmap scaledImage = Bitmap.CreateScaledBitmap(resultBitmap, 64, 64, false);

                            BitmapDescriptor icon = BitmapDescriptorFactory.FromBitmap(scaledImage);
                            resultBitmap.Recycle();
                            return (icon);
                        }
                    }
                }
            }




            void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
            {
                var customPin = GetCustomPin(e.Marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                if (!string.IsNullOrWhiteSpace(customPin.Url))
                {
                    var url = Android.Net.Uri.Parse(customPin.Url);
                    var intent = new Intent(Intent.ActionView, url);
                    intent.AddFlags(ActivityFlags.NewTask);
                    Android.App.Application.Context.StartActivity(intent);
                }
            }

            CustomPin GetCustomPin(Marker annotation)
            {
                var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
                foreach (var pin in customPins)
                {
                    if (pin.Position == position)
                    {
                        return pin;
                    }
                }
                return null;
            }

            public Android.Views.View GetInfoWindow(Marker marker)
            {
                return null;
            }

            public Android.Views.View GetInfoContents(Marker marker)
            {
                var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
                if (inflater != null)
                {
                    Android.Views.View view;

                    var customPin = GetCustomPin(marker);
                    if (customPin == null)
                    {
                        throw new Exception("Custom pin not found");
                    }

                    if (customPin.Id == "Xamarin")
                    {
                        view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                    }
                    else
                    {
                        view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                    }

                    /*
                    var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                    var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                    if (infoTitle != null)
                    {
                        infoTitle.Text = marker.Title;
                    }
                    if (infoSubtitle != null)
                    {
                        infoSubtitle.Text = marker.Snippet;
                    }
                    */
                    return view;
                }
                return null;
            }

            
        }
    }
}