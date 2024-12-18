using MyContacts.Model;

namespace MyContacts.Views;

[QueryProperty(nameof(id), "id")]
public partial class EditContactPage : ContentPage
{
    ContactsRepository repository = new ContactsRepository();
    ContactInfo contact;
    public string id { get; set; }

    public EditContactPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        contact = await repository.GetContact(Int32.Parse(id));
        selectedContact.Text = id + " " + contact.NameSurname;
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Are you Sure?", "Are you sure to delete", "Yes", "No");
        if (answer)
        {
            await repository.DeleteContact(contact);
            await Shell.Current.GoToAsync("..");
        }
    }

    private async void UpdateButton_Clicked(object? sender, EventArgs e)
    {
        if (NameEntry.Text.Length > 0)
        {
            contact.NameSurname = NameEntry.Text;
        }

        if (PhoneEntry.Text.Length > 0)
        {
            contact.PhoneNumber = PhoneEntry.Text;
        }

        if (EmailEntry.Text.Length > 0)
        {
            contact.Email = EmailEntry.Text;
        }
        
        await repository.UpdateContact(contact);
        Console.WriteLine("updated contact");
        
        await Shell.Current.GoToAsync("..");
    }
}