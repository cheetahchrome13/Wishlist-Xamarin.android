using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WishList
{
	class Container
	{
		public TextView ItemDescription;
		public ImageView ItemImage;

		public Container(View v)
		{
			this.ItemDescription = v.FindViewById<TextView>(Resource.Id.itemDescription);
			this.ItemImage = v.FindViewById<ImageView>(Resource.Id.itemImg);
		}
	}
}