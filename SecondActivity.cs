using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WishList
{
	[Activity(Label = "SecondActivity1")]
	public class SecondActivity : Activity
	{
		protected MediaPlayer player;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "second" layout resource
			SetContentView(Resource.Layout.second);

			// Create your application here
			var pic = this.Intent.GetIntExtra("picture", 0);
			var url = this.Intent.GetStringExtra("link");

			ImageView itemImg = FindViewById<ImageView>(Resource.Id.clickedItemImg);
			itemImg.SetImageResource(pic);

			Button linkButton = FindViewById<Button>(Resource.Id.linkButton);

			linkButton.Click += delegate
			{
				var uri = Android.Net.Uri.Parse(url);
				var intent = new Intent(Intent.ActionView, uri);
				StartActivity(intent);

				if (player == null)
				{
					player = MediaPlayer.Create(this, Resource.Raw.vespa_horn);
					player.Start();
				}

				else
				{
					player.Reset();
					player = MediaPlayer.Create(this, Resource.Raw.vespa_horn);
					player.Start();
				}
			};
		}
	}
}