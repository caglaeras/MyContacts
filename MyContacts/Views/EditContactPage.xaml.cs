using MyContacts.Model;

namespace MyContacts.Views;

[QueryProperty(nameof(Id), "id")]
public partial class EditContactPage : ContentPage
{
    ContactsRepository repository = new ContactsRepository();

    public string Id { get; set; }
    private ContactInfo contact;

    public EditContactPage() => InitializeComponent();

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!string.IsNullOrEmpty(Id))
        {
            contact = repository.GetContact(Int32.Parse(Id));
            if (contact != null)
            {
                NameEntry.Text = contact.NameSurname;
                PhoneEntry.Text = contact.PhoneNumber;
                EmailEntry.Text = contact.Email;
            }
        }
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (contact != null)
        {
            // Update contact details
            contact.NameSurname = NameEntry.Text;
            contact.PhoneNumber = PhoneEntry.Text;
            contact.Email = EmailEntry.Text;

            // Save updated contact
            repository.UpdateContact(contact);

            // Navigate back
            Shell.Current.GoToAsync("..");
        }
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        // Navigate back without saving changes
        Shell.Current.GoToAsync("..");
    }
}
