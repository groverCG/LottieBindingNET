using iOSFullLottieBinding;
// using iOSSlimLottieBinding;

namespace LottieBindingTestiOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new UIViewController();
        // var platformView = new SwiftLottieWrapper();
        // platformView.SetAnimationWithAnimation("AnimationFiles/loading_wave");
        // platformView.PlayAnimation();
        // vc.View.BackgroundColor = UIColor.SystemOrange;
        // vc.View!.AddSubview(platformView.View);
        // platformView.View.TranslatesAutoresizingMaskIntoConstraints = false;
        // var lottieConstraints = new[]
        // {
        //     platformView.View.WidthAnchor.ConstraintEqualTo(200),
        //     platformView.View.HeightAnchor.ConstraintEqualTo(200),
        //     platformView.View.CenterYAnchor.ConstraintEqualTo(vc.View.CenterYAnchor),
        //     platformView.View.CenterXAnchor.ConstraintEqualTo(vc.View.CenterXAnchor)
        // };
        //
        // NSLayoutConstraint.DeactivateConstraints(lottieConstraints);
        // NSLayoutConstraint.ActivateConstraints(lottieConstraints);

        var animationView = new CompatibleAnimationView();
        animationView.ContentMode = UIViewContentMode.ScaleAspectFit;
        animationView.CompatibleAnimation = new CompatibleAnimation("loading_wave.json","AnimationFiles", NSBundle.MainBundle);
        animationView.LoopAnimationCount = nfloat.PositiveInfinity;
        // animationView.
        animationView.Play();
        vc.View.BackgroundColor = UIColor.SystemOrange;
        vc.View!.AddSubview(animationView);
        animationView.TranslatesAutoresizingMaskIntoConstraints = false;
        var lottieConstraints = new[]
        {
            animationView.WidthAnchor.ConstraintEqualTo(200),
            animationView.HeightAnchor.ConstraintEqualTo(200),
            animationView.CenterYAnchor.ConstraintEqualTo(vc.View.CenterYAnchor),
            animationView.CenterXAnchor.ConstraintEqualTo(vc.View.CenterXAnchor)
        };
        
        NSLayoutConstraint.DeactivateConstraints(lottieConstraints);
        NSLayoutConstraint.ActivateConstraints(lottieConstraints);
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}