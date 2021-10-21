using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace $safeprojectname$.Behaviors
{
    public class FrameBehavior : Behavior<Frame>
    {
        protected override void OnAttached()
        {
            AssociatedObject.NavigationService.Navigating += NavigationService_Navigating;
            AssociatedObject.NavigationService.Navigated += NavigationService_Navigated;
            AssociatedObject.NavigationService.NavigationFailed += NavigationService_NavigationFailed;
        }

        private void NavigationService_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            
        }

        private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        private void NavigationService_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            
        }

        protected override void OnDetaching()
        {
            AssociatedObject.NavigationService.Navigating -= NavigationService_Navigating;
            AssociatedObject.NavigationService.Navigated -= NavigationService_Navigated;
            AssociatedObject.NavigationService.NavigationFailed -= NavigationService_NavigationFailed;
        }
    }
}
