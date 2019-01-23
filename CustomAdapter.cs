using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WishList
{
	class CustomAdapter : ArrayAdapter
	{
		private Context c;
		private List<ListItem> items;
		private LayoutInflater inflater;
		private int resource;

		public CustomAdapter(Context context, int resource, List<ListItem> items) : base(context, resource, items)
		{
			this.c = context;
			this.resource = resource;
			this.items = items;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			if (inflater == null)
			{
				inflater = (LayoutInflater)c.GetSystemService(Context.LayoutInflaterService);
			}

			if (convertView == null)
			{
				convertView = inflater.Inflate(resource, parent, false);
			}

			Container container = new Container(convertView)
			{
				ItemDescription = {Text = items[position].ItemDescription}

			};

			container.ItemImage.SetImageResource(items[position].ItemImage);
			convertView.SetBackgroundColor(position % 2 == 0 ? Color.Turquoise : Color.PaleGoldenrod);
			return convertView;
		}
	}
}