using MAUI.HTTP.Client.OpenWeatherMap.Control;

namespace MAUI.HTTP.Client.OpenWeatherMap.Behavior
{
    public class RepeaterViewBehavior : Behavior<RepeaterView>
    {
        private RepeaterView view;

        private void UpdateState()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var page = Application.Current.MainPage;

                if (page.Width > page.Height)
                {
                    view.VisualState = "Landscape";
                    return;
                }

                view.VisualState = "Portrait";
            });
        }

        void MainPage_SizeChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        protected override void OnAttachedTo(RepeaterView view)
        {
            this.view = view;

            base.OnAttachedTo(view);

            UpdateState();

            Application.Current.MainPage.SizeChanged += MainPage_SizeChanged;
        }

        protected override void OnDetachingFrom(RepeaterView view)
        {
            base.OnDetachingFrom(view);

            Application.Current.MainPage.SizeChanged -= MainPage_SizeChanged;
            this.view = null;
        }


    }
}
