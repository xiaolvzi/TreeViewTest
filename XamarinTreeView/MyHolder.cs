﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Com.Unnamed.B.Atv.Model;

namespace XamarinTreeView
{
    public class MyHolder : TreeNode.BaseNodeViewHolder
    {
        private Context mcontext;

        public MyHolder(Context context) : base(context)
        {
            mcontext = context;
        }

        public override View CreateNodeView(TreeNode p0, Java.Lang.Object p1)
        {
            var inflater = LayoutInflater.FromContext(mcontext);
            var view = inflater.Inflate(Resource.Layout.itemview, null, false);
            TextView tv = view.FindViewById<TextView>(Resource.Id.itemtv);
            //tv.Click += Tv_Click;
            var item = p1 as TreeItem;
            tv.Text = item.text;
            return view;
        }

        private void Tv_Click(object sender, EventArgs e)
        {
            Toast.MakeText(mcontext,"1111",ToastLength.Short).Show();
        }
    }
}