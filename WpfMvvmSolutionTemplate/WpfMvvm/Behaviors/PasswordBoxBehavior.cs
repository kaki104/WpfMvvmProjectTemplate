using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace $safeprojectname$.Behaviors
{
    /// <summary>
    /// 패스워드박스 비헤이비어
    /// </summary>
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        public PasswordBoxBehavior()
        {
        }

        /// <summary>
        /// 붙이기
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
            AssociatedObject.IsEnabledChanged += AssociatedObject_IsEnabledChanged;
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
        }
        /// <summary>
        /// 패스워드 체인지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextChangedCommand?.Execute(AssociatedObject.SecurePassword);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
            AssociatedObject.IsEnabledChanged -= AssociatedObject_IsEnabledChanged;
            AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }

        /// <summary>
        /// 사용 가능 상태가 변경되면 패스워드 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (AssociatedObject == null)
            {
                return;
            }

            AssociatedObject.Password = string.Empty;
        }

        /// <summary>
        /// 포커스 받을 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            AssociatedObject?.SelectAll();
        }

        /// <summary>
        /// 프리뷰 키다운 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.ImeProcessed)
            {
                if (AssociatedObject.ToolTip != null)
                {
                    return;
                }

                AssociatedObject.ToolTip = new ToolTip
                {
                    Content = "영문 키보드만 사용 가능합니다",
                    PlacementTarget = sender as UIElement,
                    Placement = PlacementMode.Bottom,
                    IsOpen = true
                };
            }
            else
            {
                if (AssociatedObject.ToolTip is ToolTip currentToolTip)
                {
                    currentToolTip.IsOpen = false;
                }

                AssociatedObject.ToolTip = null;
            }
        }

        /// <summary>
        /// 키다운 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && EnterCommand != null)
            {
                EnterCommand.Execute(AssociatedObject.SecurePassword);
                AssociatedObject.Clear();
                e.Handled = true;
                return;
            }

            if ((Keyboard.GetKeyStates(Key.CapsLock) & KeyStates.Toggled) == KeyStates.Toggled)
            {
                if (AssociatedObject.ToolTip != null)
                {
                    return;
                }

                AssociatedObject.ToolTip = new ToolTip
                {
                    Content = "CapsLock키가 눌러져있습니다",
                    PlacementTarget = sender as UIElement,
                    Placement = PlacementMode.Bottom,
                    IsOpen = true
                };
            }
            else
            {
                if (AssociatedObject.ToolTip is ToolTip currentToolTip)
                {
                    currentToolTip.IsOpen = false;
                }

                AssociatedObject.ToolTip = null;
            }
        }

        #region TextChangedCommand

        /// <summary>
        /// 패스워드가 바뀔때 커맨드
        /// </summary>
        public static readonly DependencyProperty TextChangedCommandProperty =
            DependencyProperty.Register(nameof(TextChangedCommand), typeof(ICommand), typeof(PasswordBoxBehavior),
                new PropertyMetadata(null));

        public ICommand TextChangedCommand
        {
            get => (ICommand)GetValue(TextChangedCommandProperty);
            set => SetValue(TextChangedCommandProperty, value);
        }

        #endregion TextChangedCommand

        #region EnterCommand

        /// <summary>
        /// EnterCommand
        /// </summary>
        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.Register(nameof(EnterCommand), typeof(ICommand), typeof(PasswordBoxBehavior),
                new PropertyMetadata(null));

        public ICommand EnterCommand
        {
            get => (ICommand)GetValue(EnterCommandProperty);
            set => SetValue(EnterCommandProperty, value);
        }

        #endregion EnterCommand
    }
}