using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace WishList
{
    [Activity(Label = "My Wish List", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : Activity
    {
		private CustomAdapter adapter;
		private ListView wl;
		private List<ListItem> items;
		protected MediaPlayer player;

		internal List<ListItem> Items { get => items; set => items = value; }

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);

			wl = FindViewById<ListView>(Resource.Id.wishList);
			adapter = new CustomAdapter(this, Resource.Layout.row_template, GetItems());
			wl.Adapter = adapter;
			wl.ItemClick += WishListItemClick;
		}

		void WishListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			// Experiment
			int pic = Items[e.Position].ItemImage;
			string url = Items[e.Position].ItemUrl;
			// Intent for page 2
			Intent secondIntent = new Intent(this, typeof(SecondActivity));
			secondIntent.PutExtra("picture", pic);
			secondIntent.PutExtra("link", url);
			StartActivity(secondIntent);
		}

		private List<ListItem> GetItems()
		{
			Items = new List<ListItem>()
			{
				new ListItem("1964 Vespa VBB w GS Styling - Metallic Blue", Resource.Drawable.vespa1, "http://www.planetvespa.net/catalog/assets/buypages/23/buy_23.html"),
				new ListItem("1968 Vespa VLB Sprint - Orange & White", Resource.Drawable.vespa2, "http://www.planetvespa.net/catalog/assets/buypages/14/buy_14.html"),
				new ListItem("1964 Vespa VBB Standard - Light Brown & White", Resource.Drawable.vespa3, "http://www.planetvespa.net/catalog/assets/buypages/5/buy_5.html"),
				new ListItem("1968 Vespa VLB Sprint - Olive green & white", Resource.Drawable.vespa4, "http://www.planetvespa.net/catalog/assets/buypages/26/buy_26.html"),
				new ListItem("1965 VBC Super - Lime Green", Resource.Drawable.vespa5, "http://www.planetvespa.net/catalog/assets/buypages/20/buy_20.html")
			};

			return Items;

		}

		//// Useful code for using external files:
		///
		//// NuGet File Picker Plug-In: https://www.nuget.org/packages/Xam.Plugin.FilePicker/
		//// NuGet File Picker video: https://www.youtube.com/watch?v=6Rm05cWm6Lw
		//// Docs for using external storage: https://docs.microsoft.com/en-us/xamarin/android/platform/files/external-storage?tabs=vswin
		///
		//// Code for retrieving & using image files for ImageView:
		//Bitmap bitmap = BitmapFactory.decodeFile(pathToPicture);
		//ImageView imageView = (ImageView)getActivity().findViewById(R.id.imageView);
		//imageView.setImageBitmap(bitmap);
	}
}