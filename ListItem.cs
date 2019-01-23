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
	class ListItem
	{
		public ListItem(string itemDescription, int itemImage, string itemUrl)
		{
			this.ItemDescription = itemDescription;
			this.ItemImage = itemImage;
			this.ItemUrl = itemUrl;
		}

		public string ItemDescription { get; set; }

		public int ItemImage { get; set; }

		public string ItemUrl { get; set; }
	}
}