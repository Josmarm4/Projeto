using Android.Content;
using AndroidApp1.Activities;

namespace AndroidApp1
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }
    }
}