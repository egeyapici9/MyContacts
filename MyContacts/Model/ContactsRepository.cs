using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Model
{
    public class ContactsRepository
    {
       ContactDatabase contactDatabase;
        public ContactsRepository()
        {
            contactDatabase = new ContactDatabase();
        }

        public  async Task<ObservableCollection<ContactInfo>> GetContacts() {
            var contacts = await contactDatabase.GetAllContactsAsync();
           
            return new ObservableCollection<ContactInfo>(contacts); ;
        }

        public async Task AddContact(ContactInfo contact)
        {
            await contactDatabase.InsertContact(contact);
        }

        public async Task UpdateContact(ContactInfo contact)
        {
            await contactDatabase.UpdateContract(contact);
        }

        public async Task DeleteContact(ContactInfo contact)
        {
            await contactDatabase.DeleteContact(contact);
        }
        public async Task<ContactInfo> GetContact(int id)
        {
            return  await contactDatabase.GetContactByIdAsync(id);
        }

    }
}
