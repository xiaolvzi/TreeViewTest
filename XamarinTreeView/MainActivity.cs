using Android.App;
using Android.Widget;
using Android.OS;
using Com.Unnamed.B.Atv.Model;
using Com.Unnamed.B.Atv.View;
using Java.Lang;
using Android.Views;

namespace XamarinTreeView
{
    [Activity(Label = "XamarinTreeView", MainLauncher = true)]
    public class MainActivity : Activity,TreeNode.ITreeNodeClickListener
    {

        TreeNode parent;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TreeNode root = TreeNode.InvokeRoot();

            TreeItem parent_item = new TreeItem() { text = "parent2" };
            parent = new TreeNode(parent_item).SetViewHolder(new MyHolder(this));

            ///Parent2 root children 
            TreeItem child1_item = new TreeItem() { text = "Child1" };
            TreeNode child1 = new TreeNode(child1_item).SetViewHolder(new MyHolder(this));

            TreeItem item = new TreeItem() { text = " Level1" };
            TreeNode child10 = new TreeNode(item).SetViewHolder(new MyHolder(this));
            child1.AddChild(child10);

            TreeItem item1 = new TreeItem() { text = " Level2" };
            TreeNode child11 = new TreeNode(item1).SetViewHolder(new MyHolder(this));
            child10.AddChild(child11);

            TreeItem item2 = new TreeItem() { text = " Level2-1" };
            TreeNode child111_1 = new TreeNode(item2).SetViewHolder(new MyHolder(this));
            child11.AddChild(child111_1);

            TreeItem item3 = new TreeItem() { text = " Level2-2" };
            TreeNode child111_2 = new TreeNode(item3).SetViewHolder(new MyHolder(this));
            child11.AddChild(child111_2);

            /// 

            parent.AddChildren(child1);
            root.AddChild(parent);


            AndroidTreeView atv = new AndroidTreeView(this, root);
            LinearLayout rootlayout = FindViewById<LinearLayout>(Resource.Id.rootlayout);
            rootlayout.AddView(atv.View);
            rootlayout.Invalidate();
            parent.SetClickListener(this);
        }
        public void OnClick(TreeNode p0, Object p1)
        {
            var view = parent.ViewHolder.View as View;
            int iLeft = Resource.Drawable.dapao;
            TextView tv = view.FindViewById<TextView>(Resource.Id.itemtv);
            tv.SetCompoundDrawablesWithIntrinsicBounds(iLeft, 0, 0, 0);
            tv.Text = "adfasdf";
            Toast.MakeText(this, "111", ToastLength.Short).Show();
        }
    }

    public class TreeItem : Java.Lang.Object
    {
        public string text;
    }
}