using Microsoft.Maui.ApplicationModel.Communication;
using MyContacts.Model;

namespace MyContacts.Views
{
    [QueryProperty(nameof(id), "id")]
    public partial class EditContactPage : ContentPage
    {
        ContactsRepository contactRepository = new ContactsRepository();

        private ContactInfo contactInfo;

        public string id { get; set; }

        public EditContactPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            contactInfo = contactRepository.GetContact(Int32.Parse(id));

            if (contactInfo != null)
            {
                NameEntry.Text = contactInfo.NameSurname;
                PhoneEntry.Text = contactInfo.PhoneNumber;
                EmailEntry.Text = contactInfo.Email;
            }
            else
            {
                DisplayAlert("Error", "Contact Not Found", "OK");
            }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            contactInfo.NameSurname = NameEntry.Text;
            contactInfo.PhoneNumber = PhoneEntry.Text;
            contactInfo.Email = EmailEntry.Text;

            await contactRepository.Update(contactInfo);

            await Shell.Current.GoToAsync("..");
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ContactsPage");
        }
    }
}