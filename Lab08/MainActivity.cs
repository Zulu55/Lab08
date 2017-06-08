using Android.App;
using Android.Widget;
using Android.OS;
using SALLab08;
using System;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity
    {
        TextView UserNameTextView2;
        TextView StatusTextView2;
        TextView TokenTextView2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            UserNameTextView2 = FindViewById<TextView>(Resource.Id.UserNameTextView2);
            StatusTextView2 = FindViewById<TextView>(Resource.Id.StatusTextView2);
            TokenTextView2 = FindViewById<TextView>(Resource.Id.TokenTextView2);

            //var viewGroup = (Android.Views.ViewGroup)Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var mainLayout = viewGroup.GetChildAt(0) as LinearLayout;
            //var headerImage = new ImageView(this);
            //headerImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            //mainLayout.AddView(headerImage);

            //var userNameTextView = new TextView(this);
            //userNameTextView.Text = GetString(Resource.String.UserName);
            //mainLayout.AddView(userNameTextView);

            Validate();

        }

        private async void Validate()
        {
            var serviceClient = new ServiceClient();
            var studentEmail = "jzuluaga55@gmail.com";
            var password = "Roger1974";
            var myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);

            UserNameTextView2.Text = result.Fullname;
            StatusTextView2.Text = result.Status.ToString();
            TokenTextView2.Text = result.Token;
        }
    }
}

