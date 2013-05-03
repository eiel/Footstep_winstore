using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace Footstep
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool IsAnimate;

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。Parameter 
        /// プロパティは、通常、ページを構成するために使用します。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Storyboard1.Completed += new EventHandler<object>(this.StartAnimation);
            this.StartAnimation(null,null);
            IsAnimate = true;

            this.SizeChanged += MainPage_SizeChanged;
        }

        void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           string viewstate = ApplicationView.Value.ToString();
            VisualStateManager.GoToState(this, viewstate, false);
        }

        public void StartAnimation(Object sender, Object evt)
        {
            Storyboard1.AutoReverse = true;
            Storyboard1.Begin();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if (IsAnimate)
            {
                Storyboard1.Pause();
                IsAnimate = false;
                pause_button.Content = "再開";
            }
            else
            {
                Storyboard1.Resume();
                IsAnimate = true;
                pause_button.Content = "一時停止";
            }
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            if (background.Visibility == Visibility.Visible)
            {
                background.Visibility = Visibility.Collapsed;
                hide_button.Content = "背景を表示";
            }
            else
            {
                background.Visibility = Visibility.Visible;
                hide_button.Content = "背景を隠す";
            }
        }
    }
}
