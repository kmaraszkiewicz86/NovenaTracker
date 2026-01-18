using NovenaTracker.Presentation.Views;

namespace NovenaTracker.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            // Register route for navigation with parameter
            Routing.RegisterRoute("NovennaListPage", typeof(NovennaListPage));
        }
    }
}
