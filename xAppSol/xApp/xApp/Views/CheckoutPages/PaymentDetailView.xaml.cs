using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace xApp.Views.CheckoutPages
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentDetailView
    {
        // Gets or sets the ActionTextProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty ActionTextProperty =
            BindableProperty.Create("ActionText", typeof(string), typeof(PaymentDetailView));

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceDetailView" /> class.
        /// </summary>
        public PaymentDetailView()
        {
            InitializeComponent();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the Action Text.
        /// </summary>
        public string ActionText
        {
            get { return (string)GetValue(ActionTextProperty); }
            set { this.SetValue(ActionTextProperty, value); }
        }

        #endregion
    }
}