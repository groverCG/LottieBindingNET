using Foundation;
using iOSLottieBinding;
using UIKit;

namespace LottieBindingTestiOS
{
    public class FullScreenLottieAnimationView : UIView
    {
        private SwiftLottieWrapper lottieLogo;

        public FullScreenLottieAnimationView()
        {
            
        }

        public void DisplayLottieLoadingAnimation(UIView superView, string message, UIColor color, string lottieAnimationName, float width, float height, bool underNavBar)
        {
            var wrapperView = new UIView();
            AddSubview(wrapperView);
            var wrapperConstraints = new[]
            {
                wrapperView.TopAnchor.ConstraintEqualTo(this.TopAnchor),
                wrapperView.LeadingAnchor.ConstraintEqualTo(this.LeadingAnchor),
                wrapperView.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor),
                wrapperView.BottomAnchor.ConstraintEqualTo(this.BottomAnchor)
            };
            wrapperView.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.DeactivateConstraints(wrapperConstraints);
            NSLayoutConstraint.ActivateConstraints(wrapperConstraints);

            // lottieLogo = LOTAnimationView.AnimationNamed(lottieAnimationName);
            lottieLogo = new SwiftLottieWrapper();
            lottieLogo.SetAnimationWithAnimation(lottieAnimationName);
            lottieLogo.View.ContentMode = UIViewContentMode.Center;
            // lottieLogo.PlayAnimation();
            AddSubview(lottieLogo.View);

            var lottieConstraints = new[]
            {
                lottieLogo.View.WidthAnchor.ConstraintEqualTo(width),
                lottieLogo.View.HeightAnchor.ConstraintEqualTo(height),
                lottieLogo.View.CenterYAnchor.ConstraintEqualTo(wrapperView.CenterYAnchor),
                lottieLogo.View.CenterXAnchor.ConstraintEqualTo(wrapperView.CenterXAnchor)
            };

            lottieLogo.View.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.DeactivateConstraints(lottieConstraints);
            NSLayoutConstraint.ActivateConstraints(lottieConstraints);

            var loadingDescriptionLabel = new UILabel
            {
                Text = message,
                TextColor = color,
                Font = UIFont.SystemFontOfSize(20, UIFontWeight.Semibold)
            };

            AddSubview(loadingDescriptionLabel);
            var loadingConstraints = new[]
            {
                loadingDescriptionLabel.TopAnchor.ConstraintEqualTo(lottieLogo.View.BottomAnchor, 10),
                loadingDescriptionLabel.CenterXAnchor.ConstraintEqualTo(lottieLogo.View.CenterXAnchor)
            };
            loadingDescriptionLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.DeactivateConstraints(loadingConstraints);
            NSLayoutConstraint.ActivateConstraints(loadingConstraints);

            superView.AddSubview(this);
            var thisConstraints = new[]
            {
                TopAnchor.ConstraintEqualTo(underNavBar
                    ? superView.SafeAreaLayoutGuide.TopAnchor
                    : superView.TopAnchor),
                LeadingAnchor.ConstraintEqualTo(superView.LeadingAnchor),
                TrailingAnchor.ConstraintEqualTo(superView.TrailingAnchor),
                BottomAnchor.ConstraintEqualTo(superView.BottomAnchor)
            };
            this.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.DeactivateConstraints(thisConstraints);
            NSLayoutConstraint.ActivateConstraints(thisConstraints);

            PlayLottieAnimation();
        }

        /// <summary>
        /// Alternative method to find the nearest top-most controller's view
        /// </summary>
        public void DisplayLottieLoadingAnimation(UIViewController viewController, string message, UIColor color, string lottieAnimationName, float width, float height, bool underNavBar)
        {
            UIView view = viewController.View;

            if (underNavBar)
            {
                if (viewController is UINavigationController navVC)
                {
                    view = navVC.TopViewController.View;
                }
                else if (viewController.NavigationController != null)
                {
                    view = viewController.NavigationController.TopViewController.View;
                }
            }

            DisplayLottieLoadingAnimation(view, message, color, lottieAnimationName, width, height, underNavBar);
        }

        public void DissmissLoadingAnimation()
        {
            // lottieLogo.Pause();
            RemoveFromSuperview();
        }

        private void PlayLottieAnimation()
        {
            // lottieLogo.AnimationProgress = 0;
            // lottieLogo.Play();
            lottieLogo.InitAnimation();
        }
    }
}