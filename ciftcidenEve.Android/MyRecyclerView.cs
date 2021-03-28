using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.Widget;
using static Android.Resource;

namespace ciftcidenEve
{
    public class RecylcerViewAdapter : RecyclerView.Adapter
    {
        public override int ItemCount => throw new NotImplementedException();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyHolder myHolder = holder as MyHolder;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(ciftcidenEve.Droid.Resource.Layout.abc_action_bar_title_item, parent, false);

            MyHolder myHolder = new MyHolder(row);

            return myHolder;
        }
        public class MyHolder : RecyclerView.ViewHolder
        {
            public View mView { get; set; }
            public MyHolder(View view) : base(view)
            {
                mView = view;
            }
        }
    }//eof adapter
}