// using Com.Airbnb.Lottie;

using Com.Example.Lottieslimbinding;

namespace LottieBindingTestDroid;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
        var container = this.FindViewById<RelativeLayout>(Resource.Id.container);

        var lottieAnimationView = new LottieAnimationViewWrapper(this);
        lottieAnimationView.SetAnimation("AnimationFiles/loading_wave.json");
        var relativeLayoutParams = new RelativeLayout.LayoutParams(
            1000,
            1000);

        relativeLayoutParams.AddRule(LayoutRules.CenterInParent);
        container.AddView(lottieAnimationView.View, relativeLayoutParams);
        
        lottieAnimationView.PlayAnimation();
        
    }
}