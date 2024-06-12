using iOSLottieBinding;

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
        var platformView = new SwiftLottieWrapper();
        platformView.SetAnimationWithAnimation("loading_wave.json");
        platformView.InitAnimation();
        // var platformView = new UIView();
        // platformView.BackgroundColor = UIColor.Yellow;
        vc.View.BackgroundColor = UIColor.SystemPink;
        vc.View!.AddSubview(platformView.View);
        platformView.View.TranslatesAutoresizingMaskIntoConstraints = false;
        var lottieConstraints = new[]
        {
            platformView.View.WidthAnchor.ConstraintEqualTo(100),
            platformView.View.HeightAnchor.ConstraintEqualTo(100),
            platformView.View.CenterYAnchor.ConstraintEqualTo(vc.View.CenterYAnchor),
            platformView.View.CenterXAnchor.ConstraintEqualTo(vc.View.CenterXAnchor)
        };

        NSLayoutConstraint.DeactivateConstraints(lottieConstraints);
        NSLayoutConstraint.ActivateConstraints(lottieConstraints);
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}